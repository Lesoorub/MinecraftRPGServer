using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
public class ChunkSection
{
    public sbyte Y;
    public PalettedContrainer biomes;
    public PalettedContrainer block_states;

    public const int BlocksSizePerSection = 16;
    //public short[,,] blocks = new short[BlocksSizePerSection, BlocksSizePerSection, BlocksSizePerSection];
    public const int BiomesSizePerSection = 4;
    //public short[,,] biomes = new short[BiomesSizePerSection, BiomesSizePerSection, BiomesSizePerSection];

    public byte[] SkyLight;
    public byte[] BlockLight;

    public short BlockCount;
    public byte BitsPerBlock;

    public static byte GlobalBiomesMaxBitsPerEntry => (byte)Math.Ceiling(Math.Log(ChunkSectionParser.biomeNames.Count, 2));
    public static byte GlobalBlockStatesMaxBitsPerEntry => (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2));
    public const byte BiomesThreasholdPerSection = 4;
    public const byte BlocksThreasholdPerSection = 9;

    public ChunkSection()
    {
        //biomes = new PalettedContrainer(
        //    new List<short>() { (short)BiomeID.the_void }, 
        //    null, 
        //    BiomesSizePerSection,
        //    BiomesThreasholdPerSection, 
        //    GlobalBlockStatesMaxBitsPerEntry);
        //block_states = new PalettedContrainer(
        //        palette: new List<short>() { (short)DefaultBlockState.air },
        //        data: null,
        //        size: BlocksSizePerSection,
        //        threshold: BlocksThreasholdPerSection,
        //        globalMaxBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
    }

    public short GetNumberOfBlocks()
    {
        short BlockCount = 0;
        if (block_states == null)
            return BlockCount;
        int airindex = block_states.Palette.data.FindIndex(x => x == 0);
        if (block_states.type == PaletteType.Single)
        {
            BlockCount = (short)(airindex == -1 ? 4096 : 0);
            return BlockCount;
        }
        var dat = block_states.data;
        for (int k = 0; k < dat.Length; k++)
        {
            if (dat[k] != airindex)
                BlockCount++;
        }
        return BlockCount;
        //short not_air_blocks = 0;
        //for (int x = 0; x < BlocksSizePerSection; x++)
        //    for (int y = 0; y < BlocksSizePerSection; y++)
        //        for (int z = 0; z < BlocksSizePerSection; z++)
        //            if (blocks[x, y, z] != (short)DefaultBlockState.air)
        //                not_air_blocks++;
        //return not_air_blocks;
    }
    public byte[] GetBytes() 
    {
        var writer = new ArrayWriter();
        writer.Write(BlockCount);
        //var block_states = GetBlockStates();
        writer.WriteRaw(block_states.ToByteArray((tag) => tag));
        //var biomes = GetBiomes();
        writer.WriteRaw(biomes.ToByteArray((tag) => 0));
        return writer.ToArray();
    }
    public BlockState GetBlock(int rx, int ry, int rz)
    {
        //return new BlockState(blocks[rx, ry, rz]);
        if (block_states.data != null)
            return new BlockState(
                block_states.Palette.data[
                    block_states.GetData(rx, ry, rz)
                    ]);
        else return BlockState.air;
    }
    public void SetBlock(int rx, int ry, int rz, short StateID)
    {
        //blocks[rx, ry, rz] = StateID;
        block_states.Add(rx, ry, rz, StateID);
    }

    public override string ToString()
    {
        return $"Y={Y}, BlockCount={BlockCount}, SkyLight?={SkyLight != null}, BlockLight?={BlockLight != null}";
    }

    public PalettedContrainer GetBlockStates()
    {
        throw new NotImplementedException();
        //return GetPaletteContainer(blocks, BlocksSizePerSection, BlocksThreasholdPerSection);
    }

    public PalettedContrainer GetBiomes()
    {
        throw new NotImplementedException();
        //return GetPaletteContainer(biomes, BiomesSizePerSection, BiomesThreasholdPerSection);
    }

    public PalettedContrainer GetPaletteContainer(short[,,] edata, int size, byte threashold)
    {
        var maxpalettesize = (short)Math.Pow(2, threashold);
        var palette = new List<short>();
        short[] data = new short[size * size * size];
        //calc palette
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                for (int z = 0; z < size; z++)
                {
                    var block_stateId = edata[x, y, z];
                    int paletteIndex = palette.IndexOf(block_stateId);
                    if (paletteIndex == -1)
                    {
                        palette.Add(block_stateId);
                        if (palette.Count >= maxpalettesize)
                            break;
                    }
                }
        if (palette.Count == 1)//Single
        {
            //do nothing
            data = null;
        }
        else if (palette.Count < maxpalettesize)//Indirect
        {
            int index = 0;
            for (int y = 0; y < size; y++)
                for (int z = 0; z < size; z++)
                    for (int x = 0; x < size; x++)
                    {
                        data[index++] = (short)palette.IndexOf(edata[x, y, z]);
                    }
        }
        else//Direct
        {
            palette = null;
            int index = 0;
            for (int y = 0; y < size; y++)
                for (int z = 0; z < size; z++)
                    for (int x = 0; x < size; x++)
                        data[index++] = edata[x, y, z];
        }

        //build palette
        return new PalettedContrainer(palette, data, size);
    }
}
