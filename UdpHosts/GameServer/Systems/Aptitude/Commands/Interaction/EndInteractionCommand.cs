using System;
using System.Collections.Generic;
using System.Linq;
using AeroMessages.GSS.V66.Character;
using AeroMessages.GSS.V66.Character.Event;
using GameServer.Data.SDB.Records.apt;
using GameServer.Entities;
using GameServer.Entities.Character;
using GameServer.Entities.Deployable;
using GameServer.Systems.Encounters;

namespace GameServer.Aptitude;

public class EndInteractionCommand : ICommand
{
    public EndInteractionCommand(uint id)
    {
        Id = id;
    }

    public uint Id { get; set; } 

    public bool Execute(Context context)
    {
        if (context.Targets.Count > 0)
        {
            var actingEntity = context.Self;
            if (actingEntity.GetType() == typeof(Entities.Character.CharacterEntity))
            {
                var character = actingEntity as Entities.Character.CharacterEntity;
                
                if (character.IsPlayerControlled)
                {
                    var message = new InteractionCompleted { Percent = 100 };
                    character.Player.NetChannels[ChannelType.ReliableGss].SendMessage(message, character.EntityId);
                }
            }

            var interactionEntity = context.Targets.Peek();
            var hack = (BaseEntity)interactionEntity;

            if (hack.Encounter is { Instance: IInteractionHandler encounter })
            {
                encounter.OnInteraction((BaseEntity)actingEntity, hack);

                return true;
            }

            if (hack.Encounter is { SpawnDef: { } spawnData })
            {
                context.Shard.EncounterMan.Factory.SpawnEncounter(spawnData, (CharacterEntity)actingEntity);
            }

            var abilityId = hack.Interaction.CompletedAbilityId;
            if (abilityId != 0)
            {
                context.Shard.Abilities.HandleActivateAbility(context.Shard, actingEntity, abilityId, context.Shard.CurrentTime, new AptitudeTargets(interactionEntity));
            }

            var interactionType = hack.Interaction.Type;

            if (hack is DeployableEntity { Turret: not null } deployable)
            {
                var character = actingEntity as CharacterEntity;

                deployable.Turret.SetControllingPlayer(character.Player);
            }
            else if (interactionType == InteractionType.Vehicle)
            {
                if (actingEntity.GetType() == typeof(Entities.Character.CharacterEntity) && interactionEntity.GetType() == typeof(Entities.Vehicle.VehicleEntity))
                {
                    var character = actingEntity as Entities.Character.CharacterEntity;
                    var vehicle = interactionEntity as Entities.Vehicle.VehicleEntity;

                    vehicle.AddOccupant(character);
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}