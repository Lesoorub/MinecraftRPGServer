using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.diamond_horse_armor)]
    public class diamond_horse_armor : IBaseItem, IHasCategory, IHorseArmor
    {
        public short id => 975;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.diamond_horse_armor";
        public ItemClasses @class => ItemClasses.HorseArmorItem;

        public byte category => 6;

        public byte horse_protection => 11;
        public string horse_texture => "textures/entity/horse/armor/horse_armor_diamond.png";
    }
}
