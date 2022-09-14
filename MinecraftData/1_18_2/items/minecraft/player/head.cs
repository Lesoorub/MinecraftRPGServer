using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.player_head)]
    public class player_head : IBaseItem, IHasCategory, ICanPlaceBlock
    {
        public short id => 955;
        public Rarity rarity => Rarity.uncommon;
        public byte max_stack_size => 64;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "block.minecraft.player_head";
        public ItemClasses @class => ItemClasses.SkullItem;

        public byte category => 1;

        public BlockNameID block => BlockNameID.player_head;
    }
}
