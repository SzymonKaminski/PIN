namespace GameServer.Data.SDB.Records.customdata;

public record SetPoweredStateCommandDef : ICommandDef
{
    public uint Id { get; set; }
    public bool? PowerOn { get; set; } = null;
}