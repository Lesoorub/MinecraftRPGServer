using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NBT;
using static ChunkSection;

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
    static IComparer<TAG> comparer = new TAG_Comparer();
    static Dictionary<string, BlockNameID> cast_block_name_id;

    static ChunkSectionParser()
    {
        var arr = Enum.GetNames(typeof(BlockNameID));
        cast_block_name_id = new Dictionary<string, BlockNameID>(arr.Length);
        for (int k = 0; k < arr.Length; k++)
        {
            cast_block_name_id.Add(arr[k], (BlockNameID)k);
        }
    }
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
                var palette = (biomes_tag["palette"] as TAG_List)?.data
                    .Select(x => (short)biomeNames.FindIndex(y => y.Equals(((string)x).Replace("minecraft:", ""))))
                    .ToList();
                var data = (biomes_tag["data"] as TAG_Long_Array)?.data;

                obj.biomes = new PalettedContainer(
                    palette,
                    data,
                    BiomesSizePerSection,
                    BiomesThreasholdPerSection,
                    GlobalBiomesMaxBitsPerEntry);

                if (obj.biomes.container == null)
                {
                    throw new Exception("Невозможные данные");
                }
            }
            catch (Exception e)
            {
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
                var palette = (block_states_tag["palette"] as TAG_List)?.data
                    .Select(x =>
                        StateIDFromTAG(
                            x["Name"] as TAG_String,
                            x["Properties"] as TAG_Compound
                        )
                    ).ToList();
                var data = (block_states_tag["data"] as TAG_Long_Array)?.data;
                obj.block_states = new PalettedContainer(
                    palette,
                    data,
                    size: BlocksSizePerSection,
                    threshold: BlocksThreasholdPerSection,
                    directBitsPerEntry: GlobalBlockStatesMaxBitsPerEntry);

                if (obj.block_states.container == null)
                {
                    throw new Exception("Невозможные данные");
                }
            }
            catch (Exception e)
            {
                obj.block_states = default_blockstates;
            }
        }
        else
        {
            obj.block_states = default_blockstates;
        }
        obj.BlockCount = obj.GetNumberOfBlocks();
    }



    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short StateIDFromTAG(string name, TAG_Compound propsTAG)
    {
        if (name.Length == 13 && name.Equals("minecraft:air")) return 0;

        var propsHash = StateIDFromTAGChahe.PropsHash(propsTAG);
        var cutname = name.StartsWith("minecraft:") ? name.Substring(10) : name;

        var nameHash = StateIDFromTAGChahe.StringHash(cutname);

        if (!cast_block_name_id.TryGetValue(cutname, out var nameid))
            return 0;//Неизвестный блок будет равен воздуху (0).

        if (StateIDFromTAGChahe.Get(nameHash, propsHash, out var result))
            return result;

        var data = GlobalPalette.GetBlockData(nameid);
        if (propsTAG == null)
            return data.DefaultStateID;

        var d = Convert(data.Properties, propsTAG);
#if DEBUG
        if (d.Any(x => x == 255))
        {
            throw new Exception($"Can't get stateId from name and properties: " +
                $"properties={string.Join(" ", d.Select(x => x.ToString("X")))}, " +
                $"name={name}, " +
                $"propsTag={propsTAG.ToString()}");
        }
#endif
        short r = data.States.First(x => x.Properties.Length == propsTAG.Count && x.Properties.SequenceEqual(d)).Id;

        StateIDFromTAGChahe.Add(nameHash, propsHash, r);
        return r;
        IEnumerable<byte> Convert(Dictionary<string, List<string>> pallete, TAG_Compound dict)
        {
            dict.data.Sort(comparer);
            return dict.data.Select(x => (byte)pallete[x.name]
                    .FindIndex(y => y.ToLower().Equals(x.body.ToString().ToLower()))
                );
        }
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

    class TAG_Comparer : IComparer<TAG>
    {
        public int Compare(TAG x, TAG y)
        {
            return string.Compare(x.name, y.name);
        }
    }

    public static class StateIDFromTAGChahe
    {
        static Dictionary<int, Dictionary<int, short>> data = new Dictionary<int, Dictionary<int, short>>(50);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Get(int nameHash, int propsHash, out short value)
        {
            Dictionary<int, short> dict;
            lock (data)
            {
                if (!data.TryGetValue(nameHash, out dict))
                {
                    value = 0;
                    return false;
                }
            }
            lock (dict)
            {
                if (!dict.TryGetValue(propsHash, out value))
                {
                    value = 0;
                    return false;
                }
                else
                    return true;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(int nameHash, int propsHash, short value)
        {
            Dictionary<int, short> list;
            lock (data)
            {
                if (!data.TryGetValue(nameHash, out list))
                {
                    data.Add(nameHash, list = new Dictionary<int, short>(50));
                }
            }
            lock (list)
            {
                if (!list.ContainsKey(propsHash))
                {
                    list.Add(propsHash, value);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int StringHash(string read)
        {
            int hashedValue = 307445734;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 307445734;
            }
            return hashedValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PropsHash(TAG_Compound p)
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
    }
}