﻿namespace Entities
{
    [Entity("zombie")]
    public class Zombie : LivingEntityProtocol
    {
        public override string ID => "minecraft:zombie";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 107;
        public override EntityMetadata meta { get; set; } = new ZombieMetadata();
        public Zombie(World world) : base(world) 
        {
            MaxHealth = 40;
            Health = MaxHealth;
        }
    }
}