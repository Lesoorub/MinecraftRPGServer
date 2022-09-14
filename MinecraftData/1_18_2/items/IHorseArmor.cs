namespace MinecraftData._1_18_2.items.minecraft
{
    public interface IHorseArmor
    {
        byte horse_protection { get; } //[3, 5, 7, 11]. 3 - leather, ..., 11 - diamond
        string horse_texture { get; }
    }

}
