using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.salmon_bucket)]
    public class salmon_bucket : IBaseItem, IHasCategory, IBucket
    {
        public short id => 784;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.salmon_bucket";
        public ItemClasses @class => ItemClasses.EntityBucketItem;

        public byte category => 6;

        public byte bucked_fluid_type => 2;
    }
}
