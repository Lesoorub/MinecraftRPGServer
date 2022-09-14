using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.beacon)]
    public class beacon : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 324;
        public Rarity rarity => Rarity.rare;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.beacon";
        public ItemClasses @class => ItemClasses.BlockItem;

        public byte category => 6;

        public BlockNameID block => BlockNameID.beacon;
    }
}
