namespace GameServer.Data.SDB.Records.customdata;

public record SetInteractionTypeCommandDef : ICommandDef
{
    public uint Id { get; set; }
    public byte Type { get; set; }
}