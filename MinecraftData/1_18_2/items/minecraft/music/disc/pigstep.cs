using System.Collections.Generic;
namespace MinecraftData._1_18_2.items.minecraft
{
    [Item(ItemNameID.music_disc_pigstep)]
    public class music_disc_pigstep : IBaseItem, IHasCategory, IMusicDisk
    {
        public short id => 1028;
        public Rarity rarity => Rarity.rare;
        public byte max_stack_size => 1;
        public short max_damage => 0;
        public bool is_fire_resistant => false;
        public string translation_key => "item.minecraft.music_disc_pigstep";
        public ItemClasses @class => ItemClasses.MusicDiscItem;

        public byte category => 6;

        public byte analog_output => 13;
        public short sound => 628;
    }
}
