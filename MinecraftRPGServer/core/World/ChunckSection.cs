using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
public class ChunkSection
{
    public int X;
    public sbyte Y;
    public int Z;
    public PalettedContainer biomes;
    public PalettedContainer block_states;

    public byte[] SkyLight;
    public byte[] BlockLight;

    public short BlockCount;

    #region consts

    public const int BlocksSizePerSection = 16;
    public const int BiomesSizePerSection = 4;
    public const byte GlobalBiomesMaxBitsPerEntry = 5;
    //public static readonly byte GlobalBiomesMaxBitsPerEntry = (byte)Math.Ceiling(Math.Log(ChunkSectionParser.biomeNames.Count, 2));
    public const byte GlobalBlockStatesMaxBitsPerEntry = 10;
    //public static readonly byte GlobalBlockStatesMaxBitsPerEntry = (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2));
    public const byte BiomesThreasholdPerSection = 4;
    public const byte BlocksThreasholdPerSection = 9;

    #endregion

    #region Valid check

    public bool IsValid => IsValid_biomes 
        && IsValid_block_states
        && IsValid_BlockLight
        && IsValid_SkyLight;
    public bool IsValid_biomes => biomes != null && biomes.IsValid;
    public bool IsValid_block_states => block_states != null && block_states.IsValid;
    public bool IsValid_SkyLight => true;
    public bool IsValid_BlockLight => true;

    #endregion

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
        //var writer = new ArrayWriter();
        //writer.Write(BlockCount);
        //writer.WriteRaw(block_states.ToByteArray());
        //writer.WriteRaw(biomes.ToByteArray());

        //return writer.ToArray();

        var block_states_bytes = block_states.ToByteArray();
        var biomes_bytes = biomes.ToByteArray();
        var buffer = new byte[block_states_bytes.Length + biomes_bytes.Length + 2];
        var buffer_span = new Span<byte>(buffer, 0, buffer.Length);
        BinaryPrimitives.WriteInt16BigEndian(buffer_span, BlockCount);
        Buffer.BlockCopy(block_states_bytes, 0, buffer, 2, block_states_bytes.Length);
        Buffer.BlockCopy(biomes_bytes, 0, buffer, 2 + block_states_bytes.Length, biomes_bytes.Length);
        return buffer;
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
