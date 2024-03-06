using GameServer.GRPC.EventHandlers;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcGameServerAPIClient;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GameServer.GRPC;

public static class GRPCService
{
    private static GrpcChannel _channel;
    private static GameServerAPI.GameServerAPIClient _client;

    public static void Init(string address)
    {
        _channel = GrpcChannel.ForAddress(address);
        _client = new GameServerAPI.GameServerAPIClient(_channel);
    }

    public static bool IsAvailable()
    {
        return _channel.State == ConnectivityState.Ready;
    }

    public static async Task<CharacterAndBattleframeVisuals> GetCharacterAndBattleframeVisualsAsync(long characterId)
    {
        return await _client.GetCharacterAndBattleframeVisualsAsync(new CharacterID { ID = characterId });
    }

    public static async Task ListenAsync(ConcurrentDictionary<uint, INetworkPlayer> clientMap)
    {
        var eventHandlers = Assembly.GetExecutingAssembly()
                                    .GetTypes()
                                    .Where(t => t.GetInterfaces().Contains(typeof(IEventHandler)) && t.IsClass)
                                    .Select(t => Activator.CreateInstance(t) as IEventHandler)
                                    .ToDictionary(handler => handler.SupportedType, handler => handler);


        using var listen = _client.Listen(new ListenReq());

        var reader =
            Task.Run(async () =>
                     {
                         await foreach (var evt in listen.ResponseStream.ReadAllAsync())
                         {
                             Console.WriteLine($"[GRPC] Received event: {evt.Type}, payload: {evt.Payload}");

                             var handlerKey = eventHandlers.Keys.FirstOrDefault(key => key == evt.Type);

                             if (handlerKey != null)
                             {
                                 eventHandlers[handlerKey].HandleEvent(evt, clientMap);
                             }
                         }
                     });

        await reader;
    }
}