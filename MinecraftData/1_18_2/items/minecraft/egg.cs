using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.egg)]
    public class egg : IBaseItem, IHasCategory
    {
        public short id => 794;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 16;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.egg";
        public ItemClasses @class => ItemClasses.EggItem;

        public byte category => 6;
    }
}
