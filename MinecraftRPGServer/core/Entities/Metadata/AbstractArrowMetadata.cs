public class AbstractArrowMetadata : EntityMetadata
{
    public enum AbstractArrowStatus : byte
    {
        IsCritical = 0x01,
        IsNoclip = 0x02
    }
    [Index(8)] public AbstractArrowStatus abstractArrowMetadata = 0;
    [Index(9)] public byte PriercingLevel = 0;
}