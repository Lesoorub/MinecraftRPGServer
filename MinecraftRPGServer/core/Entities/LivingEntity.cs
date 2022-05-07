using System;
using System.Collections.Generic;

public class LivingEntity : Entity
{
    public Guid EntityUUID = Guid.NewGuid();
    private float maxHealth = 20;
    private float health = 20;
    public virtual float HeadYaw { get; set; }
    public virtual float MaxHealth 
    {
        get => maxHealth; set
        {
            maxHealth = value;
            Health = Math.Min(Health, maxHealth);
        }
    }
    public virtual float RegenerationPerSecond { get; set; } = 1;
    public virtual float Health 
    {
        get => health;
        set
        {
            value = Math.Min(Math.Max(value, 0), MaxHealth);
            if (value != health)
            {
                var oldHealth = health;
                health = value;
                OnHealthChanged?.Invoke(health, oldHealth);
            }
        }
    }
    
    public delegate void HealthChangedArgs(float newHealth, float oldHealth);
    public event HealthChangedArgs OnHealthChanged;
    public LivingEntity(World world) : base(world) { }
}
