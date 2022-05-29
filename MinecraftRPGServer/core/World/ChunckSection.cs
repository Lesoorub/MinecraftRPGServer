using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
public class ChunkSection
{
    public sbyte Y;
    public PalettedContrainer biomes;
    public PalettedContrainer block_states;
    public static readonly List<string> biomeNames = Enum.GetNames(typeof(BiomeID)).ToList();

    public byte[] SkyLight;
    public byte[] BlockLight;

    public short BlockCount;
    public byte BitsPerBlock;

    public byte[] Bytes;
    public bool isChanged = false;
    public ChunkSection(NBTTag sectionNBT)
    {
        //shortcuts
        BlockLight = sectionNBT["BlockLight"] as TAG_Byte_Array;
        SkyLight = sectionNBT["SkyLight"] as TAG_Byte_Array;
        Y = sectionNBT["Y"] as TAG_Byte;

        var biomes_tag = sectionNBT["biomes"];
        var block_states_tag = sectionNBT["block_states"];
        //Try load biomes
        if (biomes_tag != null)
        {
            biomes = new PalettedContrainer(
                (biomes_tag["palette"] as TAG_List)?.data
                .Select(x => (short)biomeNames.FindIndex(y => y.Equals((x as TAG_String).data)))
                .ToList(),
                (biomes_tag["data"] as TAG_Long_Array)?.data, 4, 4, (byte)Math.Ceiling(Math.Log(biomeNames.Count, 2)));
        }
        else
        {
            biomes = new PalettedContrainer(new List<short>() { 0 }, null, 4, 4, (byte)Math.Ceiling(Math.Log(biomeNames.Count, 2)));
        }
        //Try load blocks
        if (block_states_tag != null)
        {
            block_states = new PalettedContrainer(
                palette: (block_states_tag["palette"] as TAG_List)?.data.Select(x => 
                StateIDFromTAG(
                    x["Name"] as TAG_String,
                    (x["Properties"] as TAG_Compound)?.body.ToDictionary(y => y.name, y => (y as TAG_String).data))
                ).ToList(),
                data: (block_states_tag["data"] as TAG_Long_Array)?.data, 
                size: 16, 
                threshold: 9, 
                globalMaxBitsPerEntry: (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2)));
        }
        else
        {
            block_states = new PalettedContrainer(
                palette: new List<short>() { 0 }, 
                data: null, 
                size: 16, 
                threshold: 9, 
                globalMaxBitsPerEntry: (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2)));
        }
        //Re calculate number of blocks in section
        RecalcNumberOfBlocks();
        //Chaching
        UpdateBytes();
    }
    public void RecalcNumberOfBlocks()
    {
        BlockCount = 0;
        if (block_states == null)
            return;
        int airindex = block_states.Palette.data.FindIndex(x => x == 0);
        if (block_states.type == PaletteType.Single)
        {
            BlockCount = (short)(airindex == -1 ? 4096 : 0);
            return;
        }
        var dat = block_states.data;
        for (int k = 0; k < dat.Length; k++)
        {
            if (dat[k] != airindex)
                BlockCount++;
        }
    }
    public void UpdateBytes()
    {
        var writer = new ArrayWriter();
        writer.Write(BlockCount);
        writer.WriteRaw(block_states.ToByteArray((tag) => tag));
        writer.WriteRaw(biomes.ToByteArray((tag) => 0));
        Bytes = writer.ToArray();
        isChanged = false;
    }

    short StateIDFromTAG(string name, Dictionary<string, string> propsDict)
    {
        var meta = GlobalPalette.GetMeta(name);
        var id = meta.states.Where(x => x.@default.GetValueOrDefault()).FirstOrDefault().id;
        if (propsDict != null)
        {
            var props = propsDict.ToList();
            var list = meta.states;
            for (int i = 0; i < props.Count; i++)
                list = list.Where(x => x.properties[props[i].Key].ToString().Equals(props[i].Value)).ToArray();
            if (list.Length > 0)
                id = list[0].id;
        }
        return (short)id;
    }
    public BlockState GetBlock(int rx, int ry, int rz)
    {
        if (block_states.data != null)
            return new BlockState(
                block_states.Palette.data[
                    block_states.GetData(rx, ry, rz)
                    ]);
        else return BlockState.air;
    }
    public void SetBlock(int rx, int ry, int rz, short StateID)
    {
        block_states.Add(rx, ry, rz, StateID);
        isChanged = true;
    }
}
