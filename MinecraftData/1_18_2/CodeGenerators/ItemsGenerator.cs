using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftData._1_18_2.items.minecraft;

namespace MinecraftData._1_18_2.CodeGenerators
{
    public static class ItemsGenerator
    {
        public static void GenerateCode(string inputPath, string outputPath)
        {
            var json = JsonConvert.DeserializeObject<Dictionary<string, RawItemData>>(File.ReadAllText(inputPath));

            foreach (var pair in json)
            {
                var itemname = pair.Key.Replace("minecraft:", "");
                if (itemname.StartsWith("string"))
                    itemname = "@" + itemname;

                RawItemData d = pair.Value;

                var interfaces = new List<string>() { nameof(IBaseItem) };
                if (d.category.HasValue) interfaces.Add(nameof(IHasCategory));
                if (d.defense.HasValue) interfaces.Add(nameof(IArmor));
                if (d.speed.HasValue) interfaces.Add(nameof(ITool));
                if (d.food_properties != null) interfaces.Add(nameof(IFood));
                if (d.strippables_blocks != null) interfaces.Add(nameof(IAxe));
                if (d.flattenables_block_states != null) interfaces.Add(nameof(IHovel));
                if (d.bucked_fluid_type.HasValue) interfaces.Add(nameof(IBucket));
                if (!string.IsNullOrEmpty(d.dye_color)) interfaces.Add(nameof(IDye));
                if (d.horse_protection.HasValue) interfaces.Add(nameof(IHorseArmor));
                if (d.block.HasValue) interfaces.Add(nameof(ICanPlaceBlock));
                if (d.is_complex.HasValue && d.is_complex.Value) interfaces.Add(nameof(IIsComplex));
                if (d.analog_output.HasValue) interfaces.Add(nameof(IMusicDisk));
                if (d.spawn_egg_color_1.HasValue) interfaces.Add(nameof(ISpawnEgg));

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"namespace MinecraftData._1_18_2.items.minecraft");
                sb.AppendLine(@"{");
                sb.AppendLine($"    [Item(ItemNameID.{itemname})]");
                sb.AppendLine($"    public class {itemname} : {string.Join(", ", interfaces)}");
                sb.AppendLine($@"    {{
        public short id => {d.id};
        public Rarity rarity => Rarity.{d.rarity};
        public byte max_stack_size => {d.max_stack_size};
        public short max_damage => {d.max_damage.Value};
        public bool is_fire_resistant => {d.is_fire_resistant.Value.ToString().ToLower()};
        public string translation_key => ""{d.translation_key}"";
        public ItemClasses @class => ItemClasses.{d.@class};");

                if (interfaces.Contains(nameof(IHasCategory)))
                    sb.AppendLine(
$@"
        public byte category => {d.category.Value};");

                if (interfaces.Contains(nameof(IArmor)))
                    sb.AppendLine(
$@"
        public equipment_slot equipment_slot => equipment_slot.{d.equipment_slot.ToString()};
        public byte defense => {d.defense.Value};
        public float toughness => {d.toughness.Value.ToString().Replace(",", ".")}f;
        public armor_material armor_material => armor_material.{d.armor_material.Value};
        public float knockback_resistance => {d.knockback_resistance.Value.ToString().Replace(",", ".")}f;");

                if (interfaces.Contains(nameof(ITool)))
                    sb.AppendLine(
$@"
        public short uses => {d.uses.Value};
        public float speed => {d.speed.Value.ToString().Replace(",", ".")}f;
        public float attack_damage_bonus => {d.attack_damage_bonus.Value.ToString().Replace(",", ".")}f;
        public byte level => {d.level.Value};
        public byte enchantment_value => {d.enchantment_value.Value};
        public float attack_damage => {d.attack_damage.Value.ToString().Replace(",", ".")}f;");
                if (interfaces.Contains(nameof(IFood)))
                    sb.AppendLine(
$@"
        public food_properties food_properties => new food_properties()
        {{
            nutrition = {d.food_properties.nutrition},
            saturation_modifier = {d.food_properties.saturation_modifier.ToString().Replace(",", ".")}f,
            is_meat = {d.food_properties.is_meat.ToString().ToLower()},
            can_always_eat = {d.food_properties.can_always_eat.ToString().ToLower()},
            fast_food = {d.food_properties.fast_food.ToString().ToLower()}
        }};");
                if (interfaces.Contains(nameof(IAxe)))
                    sb.AppendLine(
$@"
        public Dictionary<short, short> strippables_blocks => new Dictionary<short, short>() 
        {{
            {string.Join($",{Environment.NewLine}            ", d.strippables_blocks.Select(x => $"{{ {x.Key}, {x.Value} }}"))}
        }};");
                if (interfaces.Contains(nameof(IHovel)))
                    sb.AppendLine(
$@"
        public Dictionary<short, short> flattenables_block_states => new Dictionary<short, short>() 
        {{
            {string.Join($",{Environment.NewLine}            ", d.flattenables_block_states.Select(x => $"{{ {x.Key}, {x.Value} }}"))}
        }};");
                if (interfaces.Contains(nameof(IBucket)))
                    sb.AppendLine(
$@"
        public byte bucked_fluid_type => {d.bucked_fluid_type.Value};");

                if (interfaces.Contains(nameof(IDye)))
                    sb.AppendLine(
$@"
        public string dye_color => ""{d.dye_color}"";");

                if (interfaces.Contains(nameof(IHorseArmor)))
                    sb.AppendLine(
$@"
        public byte horse_protection => {d.horse_protection.Value};
        public string horse_texture => ""{d.horse_texture}"";");

                if (interfaces.Contains(nameof(ICanPlaceBlock)))
                    sb.AppendLine(
$@"
        public BlockNameID block => BlockNameID.{d.block.Value.ToString()};");

                if (interfaces.Contains(nameof(IIsComplex)))
                    sb.AppendLine(
$@"
        public bool is_complex => {d.is_complex.ToString().ToLower()};");
                if (interfaces.Contains(nameof(IMusicDisk)))
                    sb.AppendLine(
$@"
        public byte analog_output => {d.analog_output.Value};
        public short sound => {d.sound.Value};"); 
                if (interfaces.Contains(nameof(ISpawnEgg)))
                    sb.AppendLine(
$@"
        public int spawn_egg_color_1 => {d.spawn_egg_color_1};
        public int spawn_egg_color_2 => {d.spawn_egg_color_2};
        public byte spawn_egg_entity_type => {d.spawn_egg_entity_type};");

                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                string path = Path.Combine(outputPath, "items", "minecraft", pair.Key.Replace("minecraft:", "").Replace("_", "/") + ".cs");
                new FileInfo(path).Directory.Create();
                File.WriteAllText(path, sb.ToString());
            }
        }
        public static void GenerateItemNameID(Dictionary<string, RawItemData> input, string outputPath)
        {
            GenerateEnum(input.Select(x => x.Key.ToString().Replace("minecraft:", "").Replace("string", "@string")).Distinct().ToArray(), "ItemNameID", outputPath);
        }
        public static void GenerateClasses(Dictionary<string, RawItemData> input, string outputPath)
        {
            GenerateEnum(input.Select(x => x.Value.@class).Distinct().ToArray(), "ItemClasses", outputPath);
        }
        public static void GenerateEnum(IEnumerable<string> values, string name, string path)
        {
            string type = "byte";
            if (values.Count() > 256)
                type = "short";
            if (values.Count() > 65536 / 2)
                type = "ushort";
            if (values.Count() > 65536)
                type = "int";

            var sb = new StringBuilder();
            sb.AppendLine($"public enum {name} : {type}");
            sb.AppendLine("{");
            foreach (var cl in values)
            {
                sb.AppendLine($"    {cl},");
            }
            sb.AppendLine("}");
            File.WriteAllText(Path.Combine(path, name + ".cs"), sb.ToString());
        }
        public static void GenerateEnum(Dictionary<string, int> values, string name, string path)
        {
            string type = "byte";
            if (values.Count > 256)
                type = "short";
            if (values.Count > 65536 / 2)
                type = "ushort";
            if (values.Count > 65536)
                type = "int";

            var sb = new StringBuilder();
            sb.AppendLine($"public enum {name} : {type}");
            sb.AppendLine("{");
            foreach (var cl in values)
            {
                sb.AppendLine($"    {cl.Key} = {cl.Value},");
            }
            sb.AppendLine("}");
            File.WriteAllText(Path.Combine(path, name + ".cs"), sb.ToString());
        }
    }
    public class RawItemData
    {
        public short id;
        public Rarity rarity;
        public byte max_stack_size;
        public short? max_damage;
        public bool? is_fire_resistant;
        public string translation_key;
        public string @class;
        public byte? category;
        public string equipment_slot;
        public byte? defense;
        public float? toughness;
        public armor_material? armor_material;
        public float? knockback_resistance;
        public float? speed;
        public float? attack_damage_bonus;
        public byte? level;
        public byte? enchantment_value;
        public float? attack_damage;
        public food_properties food_properties;
        public short? uses;
        public Dictionary<short, short> strippables_blocks;
        public Dictionary<short, short> flattenables_block_states;
        public byte? bucked_fluid_type;
        public string dye_color;
        public byte? horse_protection;
        public string horse_texture;
        public BlockNameID? block;
        public bool? is_complex;
        public byte? analog_output;
        public short? sound;
        public int? spawn_egg_color_1;
        public int? spawn_egg_color_2;
        public byte? spawn_egg_entity_type;
    }
}
