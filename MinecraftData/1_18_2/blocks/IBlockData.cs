using System.Collections.Generic;
namespace MinecraftData._1_18_2.blocks.minecraft
{
    public interface IBlockData
    {
        short DefaultStateID { get; }
        state DefaultState { get; }
        float Hardness { get; }
        float ExplosionResistance { get; }
        bool IsTransparent { get; }
        MinecraftMaterial Material { get; }
        byte SoundGroup { get; }
        short DroppedItem { get; }
        Dictionary<string, List<string>> Properties { get; }
        state[] States { get; }
    }
}