using System;
using System.Collections.Generic;
using System.Linq;

public static class ChunkSectionParser
{
    public static readonly List<string> biomeNames = Enum.GetNames(typeof(BiomeID)).ToList();
    public static void Parse(this ChunkSection obj, NBTTag sectionNBT)
    {
        //shortcuts
        obj.BlockLight = sectionNBT["BlockLight"] as TAG_Byte_Array;
        obj.SkyLight = sectionNBT["SkyLight"] as TAG_Byte_Array;
        obj.Y = sectionNBT["Y"] as TAG_Byte;

        var biomes_tag = sectionNBT["biomes"];
        var block_states_tag = sectionNBT["block_states"];
        //Try load biomes
        if (biomes_tag != null)
        {
            obj.biomes = new PalettedContrainer(
                (biomes_tag["palette"] as TAG_List)?.data
                .Select(x => (short)biomeNames.FindIndex(y => y.Equals((x as TAG_String).data.Replace("minecraft:", ""))))
                .ToList(),
                (biomes_tag["data"] as TAG_Long_Array)?.data, 4, 4, (byte)Math.Ceiling(Math.Log(biomeNames.Count, 2)));
        }
        else
        {
            obj.biomes = new PalettedContrainer(new List<short>() { 0 }, null, 4, 4, (byte)Math.Ceiling(Math.Log(biomeNames.Count, 2)));
        }
        //Try load blocks
        if (block_states_tag != null)
        {
            obj.block_states = new PalettedContrainer(
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
            obj.block_states = new PalettedContrainer(
                palette: new List<short>() { 0 },
                data: null,
                size: 16,
                threshold: 9,
                globalMaxBitsPerEntry: (byte)Math.Ceiling(Math.Log(GlobalPalette.Length, 2)));
        }
        obj.BlockCount = obj.GetNumberOfBlocks();
    }
    static short StateIDFromTAG(string name, Dictionary<string, string> propsDict)
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
}