using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.bone_meal)]
    public class bone_meal : IBaseItem, IHasCategory
    {
        public short id => 826;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.bone_meal";
        public ItemClasses @class => ItemClasses.BoneMealItem;

        public byte category => 6;
    }
}
