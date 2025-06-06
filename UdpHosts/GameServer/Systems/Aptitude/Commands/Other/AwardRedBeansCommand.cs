using System;
using AeroMessages.GSS.V66.Character;
using GameServer.Data.SDB.Records.customdata;
using GameServer.Entities.Character;

namespace GameServer.Aptitude;

public class AwardRedBeansCommand : Command, ICommand
{
    private AwardRedBeansCommandDef Params;

    public AwardRedBeansCommand(AwardRedBeansCommandDef par)
: base(par)
    {
        Params = par;
    }

    public bool Execute(Context context)
    {
        // todo aptitude: make it permanent
        var target = context.Self;

        if (target is CharacterEntity { IsPlayerControlled: true } character)
        {
            character.Character_BaseController.WalletProp =
                new WalletData()
                {
                    Beans = character.Character_BaseController.WalletProp.Beans + Params.Amount,
                    Epoch = (uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };
        }
        else
        {
            Console.WriteLine("AwardRedBeansCommand fails because self is not a character (why is it running on something other than a character?)");
            return false;
        }

        return true;
    }
}