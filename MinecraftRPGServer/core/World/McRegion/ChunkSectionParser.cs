using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static ChunkSection;
public static class ChunkSectionParser
{
    public static readonly List<string> biomeNames = Enum.GetNames(typeof(BiomeID)).ToList();
    public static void Parse(ChunkSection obj, NBTTag sectionNBT)
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
            obj.biomes = new PalettedContainer(
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
            obj.biomes = new PalettedContainer(
                new List<short>() { (short)BiomeID.the_void },
                null,
                BiomesSizePerSection,
                BiomesThreasholdPerSection,
                GlobalBiomesMaxBitsPerEntry);
        }

        //Try load blocks
        if (block_states_tag != null)
        {
            obj.block_states = new PalettedContainer(
                palette: (block_states_tag["palette"] as TAG_List)?.data.Select(x =>
                StateIDFromTAG(
                    x["Name"] as TAG_String,
                    (x["Properties"] as TAG_Compound)?.data.ToDictionary(y => y.name, y => (y as TAG_String).data))
                ).ToList(),
                data: (block_states_tag["data"] as TAG_Long_Array)?.data,
                size: BlocksSizePerSection,
                threshold: BlocksThreasholdPerSection,
                directBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
        }
        else
        {
            obj.block_states = new PalettedContainer(
                palette: new List<short>() { (short)DefaultBlockState.air },
                data: null,
                size: BlocksSizePerSection,
                threshold: BlocksThreasholdPerSection,
                directBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
        }
        obj.BlockCount = obj.GetNumberOfBlocks();
    }
    static Dictionary<string, Dictionary<int, short>> chache = new Dictionary<string, Dictionary<int, short>>();

    static StringBuilder sb = new StringBuilder();
    static short StateIDFromTAG(string name, Dictionary<string, string> propsDict)
    {
        int PropsHash(Dictionary<string, string> p)
        {
            lock (sb)
            {
                sb.Clear();
                if (p == null) return 0;
                foreach (var pair in p)
                {
                    sb.Append(pair.Key);
                    sb.Append(pair.Value);
                }
                using (var sha1 = new System.Security.Cryptography.SHA1Managed())
                    return BitConverter.ToInt32(sha1.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString())), 0);
            }
        }

        var propsHash = PropsHash(propsDict);
        lock (chache)
        {
            if (chache.TryGetValue(name, out var props) && props.TryGetValue(propsHash, out var result))
                return result;

            if (!Enum.TryParse<BlockNameID>(name.Replace("minecraft:", ""), out var nameid)) return 0;

            var data = GlobalPalette.GetBlockData(nameid);
            if (propsDict == null)
                return data.DefaultStateID;

            byte[] Convert(Dictionary<string, List<string>> pallete, Dictionary<string, string> dict)
            {
                return new SortedDictionary<string, string>(dict)
                    .Select(x =>
                        (byte)pallete[x.Key]
                        .FindIndex(y =>
                            y.ToLower()
                            .Equals(x.Value)
                            )
                        )
                    .ToArray();
            }

            var d = Convert(data.Properties, propsDict);

            var r = data.States.First(x => d.SequenceEqual(x.Properties)).Id;

            if (!chache.TryGetValue(name, out var list))
                chache.Add(name, list = new Dictionary<int, short>());
            list.Add(propsHash, r);
            return r;
        }
    }
    public static NBTTag Serialize(ChunkSection obj)
    {
        var nbt = new NBTTag();
        if (obj.BlockLight != null)
            nbt["BlockLight"] = new TAG_Byte_Array(obj.BlockLight);
        if (obj.SkyLight != null)
            nbt["SkyLight"] = new TAG_Byte_Array(obj.SkyLight);
        nbt["Y"] = new TAG_Byte((byte)obj.Y);

        nbt["biomes"] = new TAG_Compound(new List<TAG>()
        {
            new TAG_List(
                data: obj.biomes.GetPalette()
                    .Select(x =>
                    {
                        return (TAG)new TAG_String("minecraft:" + Enum.GetName(typeof(BiomeID), x.value));
                    })
                    .ToList(),
                elementsType: TAG_Compound._TypeID,
                name: "palette"),
            new TAG_Long_Array(data: Convert(obj.biomes.ToByteArray()), name: "data")
        });
        nbt["block_states"] = new TAG_Compound(new List<TAG>()
        {
            new TAG_List(
                data: obj.block_states.GetPalette()
                    .Select(x =>
                    {
                        var data = GlobalPalette.GetBlockData(x.value);
                        var t = new List<TAG>()
                        {
                            new TAG_String("minecraft:" +Enum.GetName(typeof(BlockNameID), GlobalPalette.GetNameID(x.value)), "Name"),
                        };
                        var props = data.States.First(y => y.Id == x.value).Properties;
                        if (props.Length > 0)
                            t.Add(
                            new TAG_Compound(
                                body: UnpackProperties(data, props),
                                name: "Properties"));

                        return (TAG)new TAG_Compound(t);
                    })
                    .ToList(),
                elementsType: TAG_Compound._TypeID,
                name: "palette"),
            new TAG_Long_Array(data: Convert(obj.block_states.ToByteArray()), name: "data")
        });
        return nbt;
        long[] Convert(byte[] x)
        {
            long[] data = new long[x.Length / 8];
            for (int k = 0; k < data.Length; k++)
                data[k] = BitConverter.ToInt64(x, k * 8);
            return data;
        }
        List<TAG> UnpackProperties(MinecraftData._1_18_2.blocks.minecraft.IBlockData data, byte[] packed)
        {
            List<TAG> tags = new List<TAG>();
            var keys = data.Properties.Keys.ToArray();
            for (int k = 0; k < packed.Length; k++)
            {
                string key = keys[k];
                tags.Add(new TAG_String(data: data.Properties[key][packed[k]], name: key));
            }
            return tags;
        }
    }
}