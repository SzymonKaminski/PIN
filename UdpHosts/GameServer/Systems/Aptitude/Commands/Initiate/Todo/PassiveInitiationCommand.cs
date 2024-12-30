using GameServer.Data.SDB.Records.apt;

namespace GameServer.Aptitude;

public class PassiveInitiationCommand : Command, ICommand
{
    private PassiveInitiationCommandDef Params;

    public PassiveInitiationCommand(PassiveInitiationCommandDef par)
: base(par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        return true;
    }
}