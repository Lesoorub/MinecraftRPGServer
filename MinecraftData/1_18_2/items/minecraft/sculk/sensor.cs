using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.sculk_sensor)]
    public class sculk_sensor : IBaseItem, ICanPlaceBlock
    {
        public short id => 603;
        public Rarity rarity => Rarity.common;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.sculk_sensor";
        public ItemClasses @class => ItemClasses.BlockItem;

        public BlockNameID block => BlockNameID.sculk_sensor;
    }
}
