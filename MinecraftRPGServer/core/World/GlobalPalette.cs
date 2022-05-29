using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MineServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class GlobalPalette
{
    public static bool Inited = false;
    public static int Length => palette.Count;
    private static readonly List<string> blockIDs = Enum.GetNames(typeof(BlockID)).ToList();
    public static Dictionary<string, BlockMeta> palette = new Dictionary<string, BlockMeta>();

    public const string ChahePATH = "GlobalPalette.bin";
    public static void Init(byte[] blocksData)
    {
        if (Inited) return;
        Inited = true;
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();
        if (!File.Exists(ChahePATH))
        {
            InitFromJson(blocksData);
            CreateChahe();
        }
        else
        {
            InitFromChahe();
        }
        timer.Stop();
        Console.WriteLine($"GlobalPalette load {palette.Sum(x => x.Value.states != null ? x.Value.states.Length : 0)} " +
            $"blockstates for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
        Console.WriteLine(BlockMeta.state.mapping.Count);
    }
    public static string GetNameID(int stateID) => palette.FirstOrDefault(x => x.Value.states.Any(y => y.id == stateID)).Key;
    public static int[] GetStateIDs(string name) => GetMeta(name).states.Select(x => x.id).ToArray();
    public static int GetStateID(string name) => GetMeta(name).states.First(x => x.@default.HasValue && x.@default.Value).id;
    public static BlockID GetBlockID(int stateID)
    {
        string nameid = GetNameID(stateID).Replace("minecraft:", "");
        return (BlockID)blockIDs.FindIndex(x => x.Equals(nameid));
    }
    public static BlockMeta GetMeta(string name) => palette[name];
    static void InitFromJson(byte[] blocksData)
    {
        using (var ms = new MemoryStream(blocksData))
        using (var streamReader = new StreamReader(ms))
        using (var reader = new JsonTextReader(streamReader))
        {
            reader.SupportMultipleContent = true;
            var serializer = new JsonSerializer();
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    var meta = (JObject)serializer.Deserialize(reader);
                    var props = meta.Properties();
                    foreach (var property in props)
                        palette.Add(property.Name, property.Value.ToObject<BlockMeta>());
                }
            }
        }
    }
    static void CreateChahe()
    {
        var writer = new ArrayWriter();
        writer.Write(palette);
        File.WriteAllBytes(ChahePATH, writer.ToArray());
    }
    static void InitFromChahe()
    {
        var reader = new ArrayReader(File.ReadAllBytes(ChahePATH));
        palette = reader.Read<Dictionary<string, BlockMeta>>();
    }
}