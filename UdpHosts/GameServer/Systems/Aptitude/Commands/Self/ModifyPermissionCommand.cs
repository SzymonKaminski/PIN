using System;
using System.Numerics;
using AeroMessages.GSS.V66.Character.Event;
using GameServer.Data.SDB.Records.customdata;

namespace GameServer.Aptitude;

public class ModifyPermissionCommand : Command, ICommand
{
    private ModifyPermissionCommandDef Params;

    public ModifyPermissionCommand(ModifyPermissionCommandDef par)
: base(par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        var target = context.Self; // NOTE: Based on glider, it seems like it should use self, maybe that is reasonable for all 'active' style commands?
        if (target.GetType() == typeof(Entities.Character.CharacterEntity))
        {
            if (Params.Glider != null)
            {
                context.Actives.Add(this, null);
            }

            if (Params.GliderHud != null)
            {
                context.Actives.Add(this, null);
            }
        }

        return true;
    }

    public void OnApply(Context context, ICommandActiveContext activeCommandContext)
    {
        var target = context.Self;
        if (target.GetType() == typeof(Entities.Character.CharacterEntity))
        {
            var character = target as Entities.Character.CharacterEntity;

            if (Params.Glider != null)
            {
                character.SetPermissionFlag(AeroMessages.GSS.V66.Character.Controller.PermissionFlagsData.CharacterPermissionFlags.glider, (bool)Params.Glider);
            }

            if (Params.GliderHud != null)
            {
                character.SetPermissionFlag(AeroMessages.GSS.V66.Character.Controller.PermissionFlagsData.CharacterPermissionFlags.glider_hud, (bool)Params.GliderHud);
            }
        }
    }

    public void OnRemove(Context context, ICommandActiveContext activeCommandContext)
    {
        var target = context.Self;
        if (target.GetType() == typeof(Entities.Character.CharacterEntity))
        {
            var character = target as Entities.Character.CharacterEntity;

            if (Params.Glider != null)
            {
                character.SetPermissionFlag(AeroMessages.GSS.V66.Character.Controller.PermissionFlagsData.CharacterPermissionFlags.glider, (bool)!Params.Glider);
            }

            if (Params.GliderHud != null)
            {
                character.SetPermissionFlag(AeroMessages.GSS.V66.Character.Controller.PermissionFlagsData.CharacterPermissionFlags.glider_hud, (bool)!Params.GliderHud);
            }
        }
    }
}