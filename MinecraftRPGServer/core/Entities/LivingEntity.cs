using System;
using System.Collections.Generic;

public class LivingEntity : Entity
{
    public Guid EntityUUID = Guid.NewGuid();
    public virtual float HeadYaw { get; set; }
    public virtual float MaxHealth { get; set; }
    public virtual float Health { get; set; }

    public LivingEntity(World world) : base(world) { }
}
