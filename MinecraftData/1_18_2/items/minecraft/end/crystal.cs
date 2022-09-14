using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.end_crystal)]
    public class end_crystal : IBaseItem, IHasCategory
    {
        public short id => 998;
        public Rarity rarity => Rarity.rare;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.end_crystal";
        public ItemClasses @class => ItemClasses.EndCrystalItem;

        public byte category => 1;
    }
}
