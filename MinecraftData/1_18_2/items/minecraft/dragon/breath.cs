using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.dragon_breath)]
    public class dragon_breath : IBaseItem, IHasCategory
    {
        public short id => 1004;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.dragon_breath";
        public ItemClasses @class => ItemClasses.Item;

        public byte category => 10;
    }
}
