public class SnowGolemMetadata : AbstractGolemMetadata
{
    public enum SnowGolemStatus : byte
    {
        HasNoPumpkinHat = 0x00,
        HasPumpkinHat = 0x10,
    }

    [Index(16)] public SnowGolemStatus snowGolemStatus = SnowGolemStatus.HasPumpkinHat;
}