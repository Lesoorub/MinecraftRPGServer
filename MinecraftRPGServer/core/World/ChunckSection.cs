using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
public class ChunkSection
{
    public int X;
    public sbyte Y;
    public int Z;
    public PalettedContainer biomes;
    public PalettedContainer block_states;

    public const int BlocksSizePerSection = 16;
    public const int BiomesSizePerSection = 4;

    public byte[] SkyLight;
    public byte[] BlockLight;

    public short BlockCount;
    public byte BitsPerBlock;

    public static readonly byte GlobalBiomesMaxBitsPerEntry = (byte)Math.Ceiling(Math.Log(ChunkSectionParser.biomeNames.Count, 2));
    public static readonly byte GlobalBlockStatesMaxBitsPerEntry = (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2));
    public const byte BiomesThreasholdPerSection = 4;
    public const byte BlocksThreasholdPerSection = 9;

    public ChunkSection() 
    { 
    }
    public ChunkSection(int x, int z)
    {
        this.X = x;
        this.Z = z; 
        biomes = new PalettedContainer(
            palette: new List<short>() { (short)BiomeID.the_void },
            data: null,
            size: BiomesSizePerSection,
            threshold: BiomesThreasholdPerSection,
            directBitsPerEntry: GlobalBiomesMaxBitsPerEntry);
        block_states = new PalettedContainer(
            palette: new List<short>() { (short)DefaultBlockState.air },
            data: null,
            size: BlocksSizePerSection,
            threshold: BlocksThreasholdPerSection,
            directBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
    }

    public short GetNumberOfBlocks()
    {
        return (short)block_states.GetPalette().Sum(x => x.value != (short)DefaultBlockState.air ? x.count : 0);
    }
    public byte[] GetBytes() 
    {
        var writer = new ArrayWriter();
        writer.Write(BlockCount);
        writer.WriteRaw(block_states.ToByteArray());
        writer.WriteRaw(biomes.ToByteArray());

        return writer.ToArray();
    }
    public BlockState GetBlock(int rx, int ry, int rz)
    {
        return new BlockState(block_states.Get(rx, ry, rz));
    }
    public void SetBlock(int rx, int ry, int rz, short StateID)
    {
        block_states.Set(rx, ry, rz, StateID);
        BlockCount = GetNumberOfBlocks();
    }

    public override string ToString()
    {
        return $"Y={Y}, BlockCount={BlockCount}, SkyLight?={SkyLight != null}, BlockLight?={BlockLight != null}";
    }
}
