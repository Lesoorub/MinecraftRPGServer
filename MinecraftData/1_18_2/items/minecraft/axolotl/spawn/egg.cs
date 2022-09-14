using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.axolotl_spawn_egg)]
    public class axolotl_spawn_egg : IBaseItem, IHasCategory, ISpawnEgg
    {
        public short id => 873;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.axolotl_spawn_egg";
        public ItemClasses @class => ItemClasses.SpawnEggItem;

        public byte category => 6;

        public int spawn_egg_color_1 => 16499171;
        public int spawn_egg_color_2 => 10890612;
        public byte spawn_egg_entity_type => 3;
    }
}
