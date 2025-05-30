using System;
using AeroMessages.GSS.V66.Character;
using AeroMessages.GSS.V66.Character.Event;
using GameServer.Data.SDB.Records.apt;
using GameServer.Entities.Character;

namespace GameServer.Aptitude;

public class ActiveInitiationCommmand : Command, ICommand
{
    private ActiveInitiationCommandDef Params;

    public ActiveInitiationCommmand(ActiveInitiationCommandDef par)
    : base(par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        if (context.Self is CharacterEntity character)
        {
            if (character.IsPlayerControlled)
            {
                var player = character.Player;
                var message = new AbilityActivated
                {
                    ActivatedAbilityId = context.AbilityId,
                    ActivatedTime = context.InitTime,
                    AbilityCooldownsData = new AbilityCooldownsData
                    {
                        ActiveCooldowns_Group1 = Array.Empty<ActiveCooldown>(),
                        ActiveCooldowns_Group2 = Array.Empty<ActiveCooldown>(),
                        Unk = 0,
                        GlobalCooldown_Activated_Time = context.InitTime,
                        GlobalCooldown_ReadyAgain_Time = context.InitTime + 300,
                    }
                };
                Console.WriteLine($"ActivateAbility {message.ActivatedAbilityId} at {message.ActivatedTime}");
                player.NetChannels[ChannelType.ReliableGss].SendMessage(message, character.EntityId);
            }
        }

        return true;
    }
}