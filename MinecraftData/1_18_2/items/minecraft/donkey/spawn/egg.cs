using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.donkey_spawn_egg)]
    public class donkey_spawn_egg : IBaseItem, IHasCategory, ISpawnEgg
    {
        public short id => 884;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.donkey_spawn_egg";
        public ItemClasses @class => ItemClasses.SpawnEggItem;

        public byte category => 6;

        public int spawn_egg_color_1 => 5457209;
        public int spawn_egg_color_2 => 8811878;
        public byte spawn_egg_entity_type => 15;
    }
}
