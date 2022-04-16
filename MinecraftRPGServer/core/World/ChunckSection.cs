using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
public class ChunkSection
{
    public sbyte Y;
    public PalettedContrainer<string> biomes;
    public PalettedContrainer<PackedBlock> block_states;

    public byte[] SkyLight;
    public byte[] BlockLight;

    public short BlockCount;
    public byte BitsPerBlock;

    public byte[] Bytes;
    public ChunkSection(NBTTag sectionNBT)
    {
        BlockLight = sectionNBT["BlockLight"] as TAG_Byte_Array;
        SkyLight = sectionNBT["SkyLight"] as TAG_Byte_Array;
        Y = sectionNBT["Y"] as TAG_Byte;

        var biomes_tag = sectionNBT["biomes"];
        var block_states_tag = sectionNBT["block_states"];

        if (biomes_tag != null)
        {
            biomes = new PalettedContrainer<string>(
                (biomes_tag["palette"] as TAG_List)?.data.Select(x => (x as TAG_String).data).ToList(),
                (biomes_tag["data"] as TAG_Long_Array)?.data, 4, 4, 3);
        }
        else
        {
            biomes = new PalettedContrainer<string>(new List<string>() { "minecraft:void" }, null, 4, 4, 3);
        }
        if (block_states_tag != null)
        {
            block_states = new PalettedContrainer<PackedBlock>(
                (block_states_tag["palette"] as TAG_List)?.data.Select(x => new PackedBlock(
                    x["Name"] as TAG_String,
                    (x["Properties"] as TAG_Compound)?.body.ToDictionary(y => y.name, y => (y as TAG_String).data))
                ).ToList(),
                (block_states_tag["data"] as TAG_Long_Array)?.data, 16, 9, (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2)));
        }
        else
        {
            block_states = new PalettedContrainer<PackedBlock>(new List<PackedBlock>()
            {
                new PackedBlock("minecraft:air", new Dictionary<string, string>())
            }, null, 16, 9, (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2)));
        }
        RecalcNumberOfBlocks();
        UpdateBytes();
    }
    public void RecalcNumberOfBlocks()
    {
        BlockCount = 0;
        if (block_states == null)
            return;
        int airindex = block_states.Palette.data.FindIndex(x => x.Name.Equals("minecraft:air"));
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
        writer.WriteRaw(block_states.ToByteArray((tag) => StateIDFromTAG(tag)));
        writer.WriteRaw(biomes.ToByteArray((tag) => 0));
        Bytes = writer.ToArray();
    }

    int StateIDFromTAG(PackedBlock tag)
    {
        var meta = GlobalPalette.GetMeta(tag.Name);
        var id = meta.states.Where(x => x.@default.GetValueOrDefault()).FirstOrDefault().id;
        if (tag.Properties != null)
        {
            var props = tag.Properties.ToList();
            var list = meta.states;
            for (int i = 0; i < props.Count; i++)
                list = list.Where(x => x.properties[props[i].Key].ToString().Equals(props[i].Value)).ToArray();
            if (list.Length > 0)
                id = list[0].id;
        }
        return id;
    }
    public BlockState GetBlock(int rx, int ry, int rz) =>
        block_states.data != null
        ? new BlockState(StateIDFromTAG(block_states.Palette.data[block_states.GetData(rx, ry, rz)]))
        : BlockState.air;
    public readonly struct PackedBlock
    {
        public readonly string Name;
        public readonly Dictionary<string, string> Properties;

        public PackedBlock(string name, Dictionary<string, string> properties)
        {
            Name = name;
            Properties = properties;
        }
    }
}