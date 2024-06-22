using GameServer.Data.SDB.Records.aptfs;

namespace GameServer.Aptitude;

public class TargetOwnerCommand : ICommand
{
    private TargetOwnerCommandDef Params;

    public TargetOwnerCommand(TargetOwnerCommandDef par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        if (context.Owner != null)
        {
            context.Targets.Push(context.Owner);

            return true;
        }

        if (Params.FailNone == 1)
        {
            return false;
        }

        return true;
    }
}