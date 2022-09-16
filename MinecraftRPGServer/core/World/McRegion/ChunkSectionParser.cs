using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NBT;
using static ChunkSection;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

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
                .Select(x => (short)biomeNames.FindIndex(y => y.Equals(((string)x).Replace("minecraft:", ""))))
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
                palette: (block_states_tag["palette"] as TAG_List)?.data
                .Select(x =>
                    StateIDFromTAG(
                        x["Name"] as TAG_String,
                        x["Properties"] as TAG_Compound
                    )
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
    static Dictionary<string, Dictionary<int, short>> chache = new Dictionary<string, Dictionary<int, short>>(50);
    static SHA1Managed sha1 = new SHA1Managed();
    static StringBuilder sb = new StringBuilder();
    static IComparer<TAG> comparer = new TAG_Comparer();
    class TAG_Comparer : IComparer<TAG>
    {
        public int Compare(TAG x, TAG y)
        {
            return string.Compare(x.name, y.name);
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short StateIDFromTAG(string name, TAG_Compound propsTAG)
    {
        if (name.Length == 13 && name.Equals("minecraft:air")) return 0;

        var propsHash = PropsHash(propsTAG);
        lock (chache)
        {
            if (chache.TryGetValue(name, out var props) && props.TryGetValue(propsHash, out var result))
                return result;

            if (!Enum.TryParse<BlockNameID>(name.Replace("minecraft:", ""), out var nameid)) return 0;

            var data = GlobalPalette.GetBlockData(nameid);
            if (propsTAG == null)
                return data.DefaultStateID;

            IEnumerable<byte> Convert(Dictionary<string, List<string>> pallete, TAG_Compound dict)
            {
                dict.data.Sort(comparer);
                return dict.data.Select(x => (byte)pallete[x.name]
                        .FindIndex(y => y.ToLower().Equals(x.body))
                    );
            }

            var d = Convert(data.Properties, propsTAG);

            short r = data.States.First(x => x.Properties.Length == propsTAG.Count && x.Properties.SequenceEqual(d)).Id;

            if (!chache.TryGetValue(name, out var list))
                chache.Add(name, list = new Dictionary<int, short>(50));
            list.Add(propsHash, r);
            return r;
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PropsHash(TAG_Compound p)
    {
        lock (sb)
        {
            sb.Clear();
            if (p == null) return 0;
            foreach (var pair in p)
            {
                sb.Append(pair.name);
                sb.Append(pair.body);
            }
            return BitConverter.ToInt32(sha1.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString())), 0);
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