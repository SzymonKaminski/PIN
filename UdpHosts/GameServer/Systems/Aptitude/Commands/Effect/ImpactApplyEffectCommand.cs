using System;
using System.Linq;
using GameServer.Data.SDB.Records.apt;

namespace GameServer.Aptitude;

public class ImpactApplyEffectCommand : ICommand
{
    private ImpactApplyEffectCommandDef Params;

    public ImpactApplyEffectCommand(ImpactApplyEffectCommandDef par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        Context effectContext = new Context(context.Shard, context.Initiator)
        {
            InitTime = context.InitTime,
            ExecutionHint = ExecutionHint.ApplyEffect
        };

        if (Params.InheritInitPos == 1)
        {
            effectContext.InitPosition = context.InitPosition;
        }

        if (Params.PassTargets == 1)
        {
            effectContext.Targets = context.Targets;
        }

        if (Params.PassRegister == 1)
        {
            effectContext.Register = context.Register;
        }

        if (Params.PassBonus == 1)
        {
            effectContext.Bonus = context.Bonus;
        }

        // TODO: Handle Params.UseFormer, sounds targeting related
        // TODO: Handle Params.RemoveOnRollback
        if (Params.OverrideInitiator == 1)
        {
            // TODO: With who?
            effectContext.Initiator = context.Self;
        }
        else if (Params.OverrideInitiatorWithTarget == 1)
        {
            effectContext.Initiator = context.Targets.First(); // Eh?
        }

        if (Params.RemoveOnRollback == 1)
        {
            Console.WriteLine($"The ApplyEffect {Params.EffectId} specifies it should be RemovedOnRollback");
        }

        if (Params.ApplyToSelf == 1)
        {
            context.Abilities.DoApplyEffect(Params.EffectId, context.Self, effectContext);
        }
        else
        {
            foreach (IAptitudeTarget target in context.Targets)
            {
                context.Abilities.DoApplyEffect(Params.EffectId, target, effectContext);
            }
        }

        return true;
    }
}