using System;
using System.Numerics;
using AeroMessages.GSS.V66.Character.Event;
using GameServer.Data.SDB.Records.customdata;

namespace GameServer.Aptitude;

public class SetGliderParametersCommand : ICommand
{
    private SetGliderParametersCommandDef Params;

    public SetGliderParametersCommand(SetGliderParametersCommandDef par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        // TODO: Extend character to support active modifiers that are removed when the source status effect ends        
        foreach (IAptitudeTarget target in context.Targets)
        {
            if (target.GetType() == typeof(Entities.Character.CharacterEntity))
            {
                var character = target as Entities.Character.CharacterEntity;

                if (Params.Value != null)
                {
                    character.SetGliderProfileId((uint)Params.Value);
                }
            }
        }

        return true;
    }
}