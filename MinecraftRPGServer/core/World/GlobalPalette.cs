using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class GlobalPalette
{
    public static bool Inited = false;
    public static int Length => palette.Count;

    public static Dictionary<string, BlockMeta> palette = new Dictionary<string, BlockMeta>();
    public static void Init(byte[] blocksData)
    {
        if (Inited) return;
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();
        Inited = true;
        using (var ms = new MemoryStream(blocksData))
        using (StreamReader streamReader = new StreamReader(ms))
        using (JsonTextReader reader = new JsonTextReader(streamReader))
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
        timer.Stop();
        Console.WriteLine($"GlobalPalette loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
    public static string GetNameID(int stateID) => palette.FirstOrDefault(x => x.Value.states.Any(y => y.id == stateID)).Key;
    public static int[] GetStateIDs(string name) => GetMeta(name).states.Select(x => x.id).ToArray();
    public static int GetStateID(string name) => GetMeta(name).states.First(x => x.@default.HasValue && x.@default.Value).id;
    public static BlockMeta GetMeta(string name) => palette[name];
}