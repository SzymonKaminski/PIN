namespace GameServer.Data.SDB.Records.dbitems;
public record class ItemSetStatusEffectEntries
{
    public uint NumOwned { get; set; }
    public uint SfxId { get; set; }
    public uint ItemSetId { get; set; }
    public uint Id { get; set; }
}