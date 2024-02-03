using System;
using System.Collections.Generic;
using System.Threading;
using GameServer.Data.SDB;

namespace GameServer.Aptitude;

public class AbilitySystem
{
    public Factory Factory;
    private Shard Shard;

    private ulong LastUpdate = 0;
    private ulong UpdateIntervalMs = 20;

    public AbilitySystem(Shard shard)
    {
        Shard = shard;
        Factory = new Factory();
    }

    public void Tick(double deltaTime, ulong currentTime, CancellationToken ct)
    {
        if (currentTime > LastUpdate + UpdateIntervalMs)
        {
            LastUpdate = currentTime;
            foreach (var entity in Shard.Entities.Values)
            {
                if (typeof(IAptitudeTarget).IsAssignableFrom(entity.GetType()))
                {
                    ProcessTarget(entity as IAptitudeTarget);
                }
            }
        }
    }

    public void ProcessTarget(IAptitudeTarget entity)
    {
        var activeEffects = entity.GetActiveEffects();
        foreach (var activeEffect in activeEffects)
        {
            if (activeEffect?.Effect.DurationChain != null)
            {
                activeEffect.Context.ExecutionHint = ExecutionHint.DurationEffect;
                bool durationResult = activeEffect.Effect.DurationChain.Execute(activeEffect.Context);
                if (!durationResult)
                {
                    DoRemoveEffect(activeEffect);
                }
            }
        }
    }

    public void DoApplyEffect(uint effectId, IAptitudeTarget target, Context context)
    {
        if (effectId == 0)
        {
             return;
        }

        var applyContext = Context.CopyContext(context);
        applyContext.Self = target;
        applyContext.ExecutionHint = ExecutionHint.ApplyEffect;

        var effect = Factory.LoadEffect(effectId);
        target.AddEffect(effect, applyContext);
        effect.ApplyChain?.Execute(applyContext);

        foreach (var pair in applyContext.Actives)
        {
            ICommand active = pair.Value;
            active.OnApply(applyContext);
        }
    }

    public void DoRemoveEffect(EffectState activeEffect)
    {
        activeEffect.Context.ExecutionHint = ExecutionHint.RemoveEffect;
        activeEffect.Context.Self.ClearEffect(activeEffect);
        activeEffect.Effect.RemoveChain?.Execute(activeEffect.Context);

        foreach (var pair in activeEffect.Context.Actives)
        {
            ICommand active = pair.Value;
            active.OnRemove(activeEffect.Context);
        }
    }

    public void HandleVehicleCalldownRequest()
    {
        throw new NotImplementedException();
    }

    public void HandleDeployableCalldownRequest()
    {
        throw new NotImplementedException();
    }

    public void HandleResourceNodeBeaconCalldownRequest()
    {
        throw new NotImplementedException();
    }

    public void HandleLocalProximityAbilitySuccess(IShard shard, IAptitudeTarget source, uint commandId, uint time, HashSet<IAptitudeTarget> targets)
    {
        Console.WriteLine($"HandleLocalProximityAbilitySuccess Source {source}, Command {commandId}, Time {time}, Targets {string.Join(Environment.NewLine, targets)} ({targets.Count})");

        var commandDef = SDBInterface.GetRegisterClientProximityCommandDef(commandId);

        if (commandDef.AbilityId != 0)
        {
            HandleActivateAbility(shard, source, commandDef.AbilityId, time, targets);
        }

        if (commandDef.Chain != 0)
        {
            var chain = Factory.LoadChain(commandDef.Chain);
            chain.Execute(new Context(shard, source)
            {
                ChainId = commandDef.Chain,
                Targets = targets,
                InitTime = time,
                ExecutionHint = ExecutionHint.Proximity
            });
        }
    }

    public void HandleActivateAbility(IShard shard, IAptitudeTarget initiator, uint abilityId, uint activationTime, HashSet<IAptitudeTarget> targets)
    {
        var chainId = SDBInterface.GetAbilityData(abilityId).Chain;
        if (chainId == 0)
        {
            return;
        }

        var chain = Factory.LoadChain(chainId);
        chain.Execute(new Context(shard, initiator)
        {
            ChainId = chainId,
            AbilityId = abilityId,
            Targets = targets,
            InitTime = activationTime,
            ExecutionHint = ExecutionHint.Ability
        });
    }

    public void HandleTargetAbility()
    {
        throw new NotImplementedException();
    }

    public void HandleDeactivateAbility()
    {
        throw new NotImplementedException();
    }

    public void HandleActivateConsumable()
    {
        throw new NotImplementedException();
    }
}