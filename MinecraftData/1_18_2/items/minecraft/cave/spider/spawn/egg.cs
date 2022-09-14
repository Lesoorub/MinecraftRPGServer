using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.cave_spider_spawn_egg)]
    public class cave_spider_spawn_egg : IBaseItem, IHasCategory, ISpawnEgg
    {
        public short id => 878;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.cave_spider_spawn_egg";
        public ItemClasses @class => ItemClasses.SpawnEggItem;

        public byte category => 6;

        public int spawn_egg_color_1 => 803406;
        public int spawn_egg_color_2 => 11013646;
        public byte spawn_egg_entity_type => 9;
    }
}
