namespace MinecraftData._1_18_2.items.minecraft
{
    public interface IBaseItem
    {
        short id { get; }
        Rarity rarity { get; }
        byte max_stack_size { get; }
        short max_damage { get; }
        bool is_fire_resistant { get; }
        string translation_key { get; }
        ItemClasses @class { get; }
    }

}
