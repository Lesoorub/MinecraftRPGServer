using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.barrier)]
    public class barrier : IBaseItem, ICanPlaceBlock
    {
        public short id => 370;
        public Rarity rarity => Rarity.epic;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.barrier";
        public ItemClasses @class => ItemClasses.BlockItem;

        public BlockNameID block => BlockNameID.barrier;
    }
}
