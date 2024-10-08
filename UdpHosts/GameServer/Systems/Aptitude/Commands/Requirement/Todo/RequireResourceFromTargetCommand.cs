using GameServer.Data.SDB.Records.aptfs;

namespace GameServer.Aptitude;

public class RequireResourceFromTargetCommand : Command, ICommand
{
    private RequireResourceFromTargetCommandDef Params;

    public RequireResourceFromTargetCommand(RequireResourceFromTargetCommandDef par)
: base(par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        return true;
    }
}