using GrpcGameServerAPIClient;
using System.Collections.Generic;

namespace GameServer.GRPC.EventHandlers;

public interface IEventHandler
{
    string SupportedType { get; }
    void HandleEvent(Event e, IDictionary<uint, INetworkPlayer> clients);
}