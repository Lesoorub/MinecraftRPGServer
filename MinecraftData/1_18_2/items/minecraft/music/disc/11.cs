using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.music_disc_11)]
    public class music_disc_11 : IBaseItem, IHasCategory, IMusicDisk
    {
        public short id => 1025;
        public Rarity rarity => Rarity.rare;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.music_disc_11";
        public ItemClasses @class => ItemClasses.MusicDiscItem;

        public byte category => 6;

        public byte analog_output => 11;
        public short sound => 620;
    }
}
