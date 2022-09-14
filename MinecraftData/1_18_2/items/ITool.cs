namespace MinecraftData._1_18_2.items.minecraft
{
    public interface ITool
    {
        short uses { get; }
        float speed { get; } //Only tools and swords. Mine speed
        float attack_damage_bonus { get; } //Only tools and swords
        byte level { get; } //Tool level. 0 for wooden and golden, 4 for netherite
        byte enchantment_value { get; } //Only tools and swords. Enchant power. min 0, max 22
        float attack_damage { get; } //Only tools and swords
    }

}
