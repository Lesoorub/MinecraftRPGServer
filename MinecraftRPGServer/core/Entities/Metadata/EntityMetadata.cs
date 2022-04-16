using MineServer;
using System;

public class EntityMetadata : MetadataBase
{
    [Flags]
    public enum EntityStatus : byte
    {
        IsOnFire = 0x01,
        isCrouching = 0x02,
        IsSprinting = 0x08,
        IsSwimming = 0x10,
        IsInvisible = 0x20,
        HasGlowingEffect = 0x40,
        IsFlyingWithAnElytra = 0x80
    }
    [Index(0)] public readonly EntityStatus entityStatus = 0;
    [Index(1)] public readonly VarInt AirTicks = 300;
    [Index(2)] public readonly Chat? CustomName;
    [Index(3)] public readonly bool isCustomNameVisible;
    [Index(4)] public readonly bool isSilent;
    [Index(5)] public readonly bool HasNoGravity;
    [Index(6)] public readonly Pose Pose;
    [Index(7)] public readonly VarInt TicksFrozenInPowderedSnow;
}
