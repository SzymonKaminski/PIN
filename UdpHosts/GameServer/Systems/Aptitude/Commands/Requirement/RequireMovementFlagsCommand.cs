﻿using System;
using GameServer.Data.SDB.Records.aptfs;
using GameServer.Entities.Character;

namespace GameServer.Aptitude;

public class RequireMovementFlagsCommand : Command, ICommand
{
    private RequireMovementFlagsCommandDef Params;

    public RequireMovementFlagsCommand(RequireMovementFlagsCommandDef par)
        : base(par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        bool result = false;

        // NOTE: Investigate target handling
        var target = context.Self;

        if (target is CharacterEntity character)
        {
            if (Params.Crouch == 1 && character.MovementStateContainer.Crouch)
            {
                result = true;
            }
            else if (Params.Sprint == 1 && character.MovementStateContainer.Sprint)
            {
                result = true;
            }
        }
        else
        {
            Console.WriteLine($"RequireMovementFlagsCommand fails because target is not a Character. If this is happening, we should investigate why.");
        }

        if (Params.Negate == 1)
        {
            result = !result;
        }

        return result;
    }
}