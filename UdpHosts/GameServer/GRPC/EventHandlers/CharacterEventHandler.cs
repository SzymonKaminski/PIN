using GrpcGameServerAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.GRPC.EventHandlers;

public class CharacterEventHandler : IEventHandler
{
    public string SupportedType => "character_visuals_updated";

    public async void HandleEvent(Event e, IDictionary<uint, INetworkPlayer> clients)
    {
        if (!long.TryParse(e.Payload, out var characterGuid))
        {
            Console.WriteLine($"Failed to parse character guid: {e.Payload}");
            return;
        }

        switch (e.Type)
        {
            case "character_visuals_updated":
                var remoteData = await GRPCService.GetCharacterAndBattleframeVisualsAsync(characterGuid);

                clients.Values.FirstOrDefault(p => p.CharacterId + 0xFE == (ulong)characterGuid)
                       ?.CharacterEntity.LoadRemote(remoteData);
                break;
        }
    }
}