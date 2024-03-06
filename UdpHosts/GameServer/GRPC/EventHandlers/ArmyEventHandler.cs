using AeroMessages.GSS.V66.Character.Event;
using GrpcGameServerAPIClient;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.GRPC.EventHandlers;

public class ArmyInfoChangedEventHandler : IEventHandler
{
    public string SupportedType => "army_info_change";

    public void HandleEvent(Event e, IDictionary<uint, INetworkPlayer> clients)
    {
        if (!ulong.TryParse(e.Payload, out var armyGuid))
        {
            return;
        }

        var armyMembers = clients.Values
                                 .Where(p => p.CharacterEntity.Character_BaseController.ArmyGUIDProp == armyGuid);

        foreach (var armyMember in armyMembers)
        {
            armyMember.NetChannels[ChannelType.ReliableGss]
                      .SendIAero(new ReceivedWebUIMessage() { Message = "{\"message_type\":\"" + SupportedType + "\"}" },
                                 armyMember.CharacterId);
        }
    }
}

public class ArmyIdChangedEventHandler : IEventHandler
{
    public string SupportedType => "army_id_changed";

    public void HandleEvent(Event e, IDictionary<uint, INetworkPlayer> clients)
    {
        var payload = e.Payload.Split(';');
        if (!ulong.TryParse(payload[0], out var armyGuid)
            || !ulong.TryParse(payload[1], out var charGuid)
            || !byte.TryParse(payload[2], out var isOfficer))
        {
            return;
        }

        var player = clients.Values.FirstOrDefault(p => p.CharacterId + 0xFE == charGuid)
                            ?.CharacterEntity.Character_BaseController;

        if (player == null)
        {
            return;
        }

        player.ArmyGUIDProp = armyGuid;
        player.ArmyIsOfficerProp = isOfficer;
    }
}
