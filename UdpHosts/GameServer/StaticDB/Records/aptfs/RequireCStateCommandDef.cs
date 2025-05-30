namespace GameServer.Data.SDB.Records.aptfs;
public record class RequireCStateCommandDef : ICommandDef
{
    public uint Id { get; set; }
    public byte Respawning { get; set; }
    public byte Incapacitated { get; set; }
    public byte Traumatized { get; set; }
    public byte Ghost { get; set; }
    public byte Living { get; set; }
    public byte Dead { get; set; }
    public byte Spawning { get; set; }
    public byte FromInitiator { get; set; }
}