using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.elytra)]
    public class elytra : IBaseItem, IHasCategory
    {
        public short id => 669;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 1;
        public short max_damage => 432;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.elytra";
        public ItemClasses @class => ItemClasses.ElytraItem;

        public byte category => 3;
    }
}
