namespace MinecraftData._1_18_2.items.minecraft
{
    public interface IArmor
    {
        equipment_slot equipment_slot { get; }
        byte defense { get; }
        float toughness { get; }
        armor_material armor_material { get; }
        float knockback_resistance { get; }
    }

}
