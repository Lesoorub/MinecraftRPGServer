using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using NBT;
using static ChunkSection;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Buffers.Binary;

public static class ChunkSectionParser
{
    public static readonly List<string> biomeNames = Enum.GetNames(typeof(BiomeID)).ToList();

    static PalettedContainer default_biomes => 
        new PalettedContainer(
            new List<short>() { (short)BiomeID.the_void },
            null,
            BiomesSizePerSection,
            BiomesThreasholdPerSection,
            GlobalBiomesMaxBitsPerEntry);
    static PalettedContainer default_blockstates => 
        new PalettedContainer(
            palette: new List<short>() { (short)DefaultBlockState.air },
            data: null,
            size: BlocksSizePerSection,
            threshold: BlocksThreasholdPerSection,
            directBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);
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
            try
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
            catch (Exception e)
            {
#if DEBUG
                throw e;
#endif
                obj.biomes = default_biomes;
            }
        }
        else
        {
            obj.biomes = default_biomes;
        }

        //Try load blocks
        if (block_states_tag != null)
        {
            try
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
            catch (Exception e)
            {
#if DEBUG
                throw e;
#endif
                obj.block_states = default_blockstates;
            }
        }
        else
        {
            obj.block_states = default_blockstates;
        }
        obj.BlockCount = obj.GetNumberOfBlocks();
    }
    static Dictionary<int, Dictionary<int, short>> read_only_chache = new Dictionary<int, Dictionary<int, short>>(50);
    static Dictionary<int, Dictionary<int, short>> chache = new Dictionary<int, Dictionary<int, short>>(50);
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
        var nameHash = StringHash(name);

        if (read_only_chache.TryGetValue(nameHash, out var props) && props.TryGetValue(propsHash, out var result))
            return result;
        if (!Enum.TryParse<BlockNameID>(name.Replace("minecraft:", ""), out var nameid)) return 0;

        var data = GlobalPalette.GetBlockData(nameid);
        if (propsTAG == null)
            return data.DefaultStateID;

        IEnumerable<byte> Convert(Dictionary<string, List<string>> pallete, TAG_Compound dict)
        {
            dict.data.Sort(comparer);
            return dict.data.Select(x => (byte)pallete[x.name]
                    .FindIndex(y => y.ToLower().Equals(x.body.ToString().ToLower()))
                );
        }

        var d = Convert(data.Properties, propsTAG);
        if (d.Any(x => x == 255))
        {
#if DEBUG
            throw new Exception($"Can't get stateId from name and properties: " +
                $"properties={string.Join(" ", d.Select(x => x.ToString("X")))}, " +
                $"name={name}, " +
                $"propsTag={propsTAG.ToString()}");
#endif
            return 0;
        }
        short r = data.States.First(x => x.Properties.Length == propsTAG.Count && x.Properties.SequenceEqual(d)).Id;

        lock (chache)
        {
            if (!chache.TryGetValue(nameHash, out var list))
            {
                chache.Add(nameHash, list = new Dictionary<int, short>(50));
                read_only_chache.Add(nameHash, new Dictionary<int, short>(50));
            }
            if (!list.ContainsKey(propsHash))
            {
                list.Add(propsHash, r);
                read_only_chache[nameHash].Add(propsHash, r);
            }
            return r;
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PropsHash(TAG_Compound p)
    {
        if (p == null) return 0;
        int hash = 1;
        foreach (var pair in p)
        {
            hash *= StringHash(pair.name);
            hash *= StringHash(pair.body as string);
        }
        return hash;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int StringHash(string read)
    {
        int hashedValue = 307445734;
        for (int i = 0; i < read.Length; i++)
        {
            hashedValue += read[i];
            hashedValue *= 307445734;
        }
        return hashedValue;
    }
    public static NBTTag Serialize(ChunkSection obj)
    {
        var nbt = new NBTTag();
        if (obj.BlockLight != null)
            nbt["BlockLight"] = obj.BlockLight;
        if (obj.SkyLight != null)
            nbt["SkyLight"] = obj.SkyLight;
        nbt["Y"] = (byte)obj.Y;

        nbt["biomes"] = new TAG_Compound(new List<TAG>()
        {
            new TAG_List(
                data: obj.biomes.GetPalette()
                    .Select(x =>
                    {
                        return (TAG)new TAG_String("minecraft:" + Enum.GetName(typeof(BiomeID), x.value));
                    })
                    .ToList(),
                elementsType: TAG_String._TypeID,
                name: "palette"),
        });
        var biomes_data = obj.biomes.GetData();
        if (biomes_data?.Length > 0)
        {
            var tmp = PalettedContainer.UnpackData(4, 4, biomes_data);
            if (tmp.Any(x => x >= obj.biomes.GetPalette().Count))
                ;
            nbt["biomes"]["data"] = new TAG_Long_Array(data: biomes_data);
        }
        nbt["block_states"] = new TAG_Compound(new List<TAG>()
        {
            new TAG_List(
                data: obj.block_states.GetPalette()
                    .Select(x =>
                    {
                        var data = GlobalPalette.GetBlockData(x.value);
                        var t = new List<TAG>()
                        {
                            new TAG_String("minecraft:" + Enum.GetName(typeof(BlockNameID), GlobalPalette.GetNameID(x.value)), "Name"),
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
        });

        var block_states_data = obj.block_states.GetData();
        if (block_states_data?.Length > 0)
            nbt["block_states"]["data"] = new TAG_Long_Array(data: block_states_data);

        return nbt;
        //long[] ToArrayOfLongs(byte[] x)
        //{
        //    long[] data = new long[x.Length / 8];
        //    for (int k = 0; k < data.Length; k++)
        //    {
        //        data[k] = BinaryPrimitives.ReadInt64BigEndian(x.AsSpan(k * 8));
        //    }
        //    return data;
        //}
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