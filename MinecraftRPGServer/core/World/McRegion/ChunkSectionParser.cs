using System;
using System.Collections.Generic;
using System.Linq;
using static ChunkSection;
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
                (biomes_tag["data"] as TAG_Long_Array)?.data, 
                BiomesSizePerSection, 
                BiomesThreasholdPerSection, 
                GlobalBiomesMaxBitsPerEntry);
        }
        else
        {
            obj.biomes = new PalettedContrainer(
                new List<short>() { (short)BiomeID.the_void },
                null,
                BiomesSizePerSection,
                BiomesThreasholdPerSection,
                GlobalBiomesMaxBitsPerEntry);
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
                size: BlocksSizePerSection,
                threshold: BlocksThreasholdPerSection,
                globalMaxBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
        }
        else
        {
            obj.block_states = new PalettedContrainer(
                palette: new List<short>() { (short)DefaultBlockState.air },
                data: null,
                size: BlocksSizePerSection,
                threshold: BlocksThreasholdPerSection,
                globalMaxBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
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

    static short[,,] Convert(PalettedContrainer palette, int size)
    {
        if (palette.type == PaletteType.Single)
        {
            short value = palette.Palette.data[0];
            short[,,] data = new short[size, size, size];
            for (int y = 0; y < size; y++)
                for (int z = 0; z < size; z++)
                    for (int x = 0; x < size; x++)
                        data[x, y, z] = value;
            return data;
        }
        else if (palette.type == PaletteType.Indirect)
        {
            short[,,] data = new short[size, size, size];
            int index = 0;
            for (int y = 0; y < size; y++)
                for (int z = 0; z < size; z++)
                    for (int x = 0; x < size; x++)
                        data[x, y, z] = palette.Palette.data[palette.data[index++]];
            return data;
        }
        else
        {
            short[,,] data = new short[size, size, size];
            int index = 0;
            for (int y = 0; y < size; y++)
                for (int z = 0; z < size; z++)
                    for (int x = 0; x < size; x++)
                        data[x, y, z] = palette.data[index++];
            return data;
        }
    }
}