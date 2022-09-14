using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.bucket)]
    public class bucket : IBaseItem, IHasCategory, IBucket
    {
        public short id => 776;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.bucket";
        public ItemClasses @class => ItemClasses.BucketItem;

        public byte category => 6;

        public byte bucked_fluid_type => 0;
    }
}
