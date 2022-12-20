using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MinecraftData._1_18_2.CodeGenerators
{
    public static class BlocksGenerator
    {
        private static void WriteJson(string path, object value)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };
            File.WriteAllText(path, JsonConvert.SerializeObject(value, settings));
        }
        public static void ConvertRawDataBlockFormatToBlockFormat(string inJsonPath, string outputJsonPath)
        {
            var rdbf = Tools.ReadBigJson<RawDataBlockFormat>(inJsonPath);

            var materials = rdbf.Select(x => x.Value.states.First().Value.material).Distinct().ToArray();

            Dictionary<string, List<string>> getParams(Dictionary<short, RawDataBlockFormat.state> states)
            {
                var t = new Dictionary<string, List<string>>();
                foreach (var state in states)
                    if (state.Value.properties != null)
                        foreach (var prop in state.Value.properties)
                        {
                            if (!t.ContainsKey(prop.Key))
                                t.Add(prop.Key, new List<string>());
                            var val = prop.Value.ToString();
                            if (!t[prop.Key].Contains(val))
                                t[prop.Key].Add(val);
                        }
                if (t.Count == 0)
                    return null;
                return t;
            }
            Dictionary<string, List<string>> currentProps;
            var bf = rdbf.ToDictionary(x => x.Key, rawDataBlockFormat => new BlockData()
            {
                DefaultStateID = rawDataBlockFormat.Value.default_state,
                Hardness = rawDataBlockFormat.Value.states.First().Value.hardness,
                ExplosionResistance = rawDataBlockFormat.Value.explosion_resistance,
                Material = rawDataBlockFormat.Value.states.First().Value.material,
                Properties = currentProps = getParams(rawDataBlockFormat.Value.states),
                IsTransparent = !rawDataBlockFormat.Value.states.First().Value.is_opaque,
                DroppedItem = rawDataBlockFormat.Value.item_id,
                SoundGroup = rawDataBlockFormat.Value.sound_group,
                States = rawDataBlockFormat.Value.states.Select(rawstate => new BlockData.state()
                {
                    Id = rawstate.Key,
                    Properties = currentProps != null ? currentProps.Select(x => (byte)x.Value.IndexOf((string)(rawstate.Value.properties[x.Key].ToString()))).ToArray() : null,
                    CollisionShape = rawstate.Value.collision_shape,
                    LightCost = rawstate.Value.light_block,
                    HasSideTransparency = rawstate.Value.has_side_transparency

                }).ToArray(),
            });
            WriteJson(outputJsonPath, bf);
        }
        public static void GenerateCode(string jsonInPath, string outputCodeDir)
        {
            if (!File.Exists(jsonInPath)) return;
            new DirectoryInfo(outputCodeDir).Create();
            var bd = Tools.ReadBigJson<BlockData>(jsonInPath);
            var materials = bd.Select(x => x.Value.Material).Distinct().ToArray();
            File.WriteAllText(Path.Combine(outputCodeDir, "MinecraftMaterial.cs"),
$@"namespace MinecraftData._1_18_2.blocks.minecraft 
{{
    public enum MinecraftMaterial : byte
    {{
        {string.Join($",{Environment.NewLine}        ", materials.Select(x => x.Replace("minecraft:", "")))}
    }}
}}");


            new DirectoryInfo(Path.Combine(outputCodeDir, "blocks")).Create();
            foreach (var pair in bd)
            {
                StringBuilder blocks = new StringBuilder();
                blocks.AppendLine(@"using System.Collections.Generic;");
                blocks.AppendLine(
$@"namespace MinecraftData._1_18_2.blocks.minecraft
{{
    [Block(BlockNameID.{pair.Key.Replace("minecraft:", "")})]
    public class {pair.Key.Replace("minecraft:", "")} : IBlockData
    {{
        public short DefaultStateID => {pair.Value.DefaultStateID};
        public state DefaultState => States[{pair.Value.States.ToList().FindIndex(x => x.Id == pair.Value.DefaultStateID)}];
        public float Hardness => {pair.Value.Hardness.ToString().Replace(",", ".")}f;
        public float ExplosionResistance => {pair.Value.ExplosionResistance.ToString().Replace(",", ".")}f;
        public bool IsTransparent => {pair.Value.IsTransparent.ToString().ToLower()};
        public byte SoundGroup => {pair.Value.SoundGroup};
        public short DroppedItem => {pair.Value.DroppedItem};
        public MinecraftMaterial Material => MinecraftMaterial.{pair.Value.Material.Replace("minecraft:", "")};
        public Dictionary<string, List<string>> Properties => new Dictionary<string, List<string>>()
        {{
            {(pair.Value.Properties == null ? "" : string.Join($",{Environment.NewLine}            ", pair.Value.Properties.Select(xpair => $"{{ \"{xpair.Key}\", new List<string>() {{ {string.Join(", ", xpair.Value.Select(x => $"\"{x}\""))} }} }}")))}
        }};
        public state[] States => new state[]
        {{{string.Join(",", pair.Value.States.Select(xpair => $@"
            new state
            {{
                Id = {xpair.Id},
                Properties = new byte[] {{ {(xpair.Properties == null ? "" : string.Join(",", xpair.Properties))} }},
                CollisionShape = {(xpair.CollisionShape.HasValue ? xpair.CollisionShape.Value.ToString() : "null")},
                LightCost = {xpair.LightCost},
                HasSideTransparency = {xpair.HasSideTransparency.ToString().ToLower()},
            }}"))}
        }};
    }}
}}");
                string path = Path.Combine(outputCodeDir, "blocks", "minecraft", pair.Key.Replace("minecraft:", "").Replace("_", "\\") + ".cs");
                new FileInfo(path).Directory.Create();
                File.WriteAllText(path, blocks.ToString());
            }
        }
#pragma warning disable CS0649
        class BlockData
        {
            public short DefaultStateID;
            public float Hardness;
            public float ExplosionResistance;
            public bool IsTransparent;
            public byte SoundGroup;
            public string Material;
            public short DroppedItem;
            public Dictionary<string, List<string>> Properties;
            public state[] States;
            public struct state
            {
                public short Id;
                public byte[] Properties;
                public short? CollisionShape;
                public byte LightCost;//block light cost
                public bool HasSideTransparency;
            }
        }
        /// <summary>
        /// https://gitlab.com/Bixilon/pixlyzer-data/-/tree/master/version/1.18.2
        /// blocks.json
        /// </summary>
        class RawDataBlockFormat
        {
            public short id;
            public float explosion_resistance;
            [JsonProperty("item")]
            public short item_id;
            public short default_state;
            [JsonProperty("class")]
            public string @class;
            public byte sound_group;
            public Dictionary<short, state> states;
            public class state
            {
                public bool has_side_transparency = false;
                public bool requires_tool;
                public float hardness;
                public bool is_opaque = true;
                public string material;
                public Dictionary<string, dynamic> properties;
                public short? collision_shape;
                public short? outline_shape;
                public bool? large_collision_shape;
                public bool? is_collision_shape_full_block;
                /// <summary>
                /// Полупрозрачный
                /// </summary>
                public bool? translucent;
                /// <summary>
                /// In Java Edition, all of the following light-filtering blocks decrease sky light by 1 level (but do not affect block light).
                /// </summary>
                public byte light_block = 0;//block light cost
                public dynamic occlusion_shape;
            }
        }
#pragma warning restore CS0649
    }
}