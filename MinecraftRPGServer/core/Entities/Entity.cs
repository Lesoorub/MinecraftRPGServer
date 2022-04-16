using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using MineServer;
using Packets.Play;

public abstract class Entity : IDisposable
{
    public static int global_id = 1;

    public int EntityID;
    /// <summary>
    /// What's is it?
    /// </summary>
    protected Guid ObjectUUID = Guid.NewGuid();
    /// <summary>
    /// Meaning dependent on the value of the Type field, see Object Data for details. https://wiki.vg/Object_Data
    /// </summary>
    protected int Data;
    /// <summary>
    /// Numbering value from table. https://wiki.vg/Entity_metadata
    /// </summary>
    public virtual int EntityType { get; }
    public virtual v2f BoxCollider { get; }
    /// <summary>
    /// Entity ID, minecraft:player, minecraft:armor_stand and e.t.c
    /// </summary>
    public virtual string ID { get; }
    public virtual v3f Position { get; set; } = new v3f(0, 64, 0);
    public virtual v3f Velocity { get; set; } = new v3f(0, 0, 0);
    public virtual v2f Rotation { get; set; } = new v2f(0, 0);
    public virtual EntityMetadata meta { get; set; }
    public virtual bool RotationSynchronization { get; } = true;
    public virtual bool HeadRotationSynchronization { get; } = true;
    public virtual bool TeleportSynchronization { get; } = true;
    public virtual bool PositionSynchronization { get; } = true;
    public virtual bool OnGround { get; set; } = false;
    public World world;
    public Entity(World world)
    {
        this.world = world;
        while (world.Entities.ContainsKey(global_id))
        {
            global_id++;
            global_id %= int.MaxValue - 1;
        }
        EntityID = global_id;
        world.Entities.TryAdd(EntityID, this);
        meta.InitFields();
    }

    public bool Disposed { get; private set; } = false;
    public virtual void Dispose()
    {
        world.Entities.TryRemove(EntityID, out var _);
        Disposed = true;
    }

    /// <summary>
    /// Optimized
    /// </summary>
    /// <param name="radius"></param>
    /// <returns></returns>
    public IEnumerable<Entity> GetEntityInRadius(v3f position, float sqrRadius)
    {
        //Now it's not optimized
        //TODO OPTIMIZE THIS!!!!
        return world.Entities.Where(x => v3f.SqrDistance(x.Value.Position, position) <= sqrRadius).Select(x => x.Value);
    }
    /// <summary>
    /// Slow
    /// </summary>
    public void Destroy()
    {
        foreach (var player_pair in Player.players)
        {
            if (player_pair.Value.view.players.ContainsKey(EntityID))
                player_pair.Value.SendDestroyEntities(new int[] { EntityID });
        }
    }

    public void SendChangePositionAndRotation(NetworkProvider network, v3f PreviousPosition)
    {
        var deltapos = Position - PreviousPosition;
        void f()
        {
            if (PositionSynchronization)
                network.Send(new EntityPositionAndRotation()
                {
                    EntityID = EntityID,
                    DeltaX = (short)(deltapos.x * 4096),
                    DeltaY = (short)(deltapos.y * 4096),
                    DeltaZ = (short)(deltapos.z * 4096),
                    Yaw = new Angle(Rotation.x),
                    Pitch = new Angle(Rotation.y),
                    OnGround = OnGround,
                });
            else
                SendRotation(network);
            if (HeadRotationSynchronization)
                network.Send(new EntityHeadLook()
                {
                    EntityID = EntityID,
                    HeadYaw = new Angle(Rotation.x),
                });
        }
        if (TeleportSynchronization && deltapos.SqrMagnitude > 8 * 8)
        {
            network.Send(new EntityTeleport()
            {
                EntityID = EntityID,
                Yaw = new Angle(Rotation.x),
                Pitch = new Angle(Rotation.y),
                X = Position.x,
                Y = Position.y,
                Z = Position.z,
                OnGround = OnGround,
            });
            return;
        }
        f();
    }
    public void SendChangePosition(NetworkProvider network, v3f PreviousPosition)
    {
        var deltapos = Position - PreviousPosition;
        void f() => network.Send(new EntityPosition()
        {
            EntityID = EntityID,
            DeltaX = (short)(deltapos.x * 4096),
            DeltaY = (short)(deltapos.y * 4096),
            DeltaZ = (short)(deltapos.z * 4096),
            OnGround = OnGround,
        });
        if (TeleportSynchronization && deltapos.SqrMagnitude > 8 * 8)
        {
            network.Send(new EntityTeleport()
            {
                EntityID = EntityID,
                Yaw = new Angle(Rotation.x),
                Pitch = new Angle(Rotation.y),
                X = Position.x,
                Y = Position.y,
                Z = Position.z,
                OnGround = OnGround,
            });
            return;
        }
        f();
    }
    public void SendRotation(NetworkProvider network)
    {
        if (!RotationSynchronization) return;
        network.Send(new EntityRotation()
        {
            EntityID = EntityID,
            Yaw = new Angle(Rotation.x),
            Pitch = new Angle(Rotation.y),
            OnGround = OnGround,
        });
        if (!HeadRotationSynchronization) return;
        network.Send(new EntityHeadLook()
        {
            EntityID = EntityID,
            HeadYaw = new Angle(Rotation.x),
        });
    }
    public void SendVelosity(NetworkProvider network)
    {
        network.Send(new EntityVelocity()
        {
            EntityID = EntityID,
            VelocityX = (short)(Velocity.x * 8000),
            VelocityY = (short)(Velocity.y * 8000),
            VelocityZ = (short)(Velocity.z * 8000),
        });
    }

    public void LoadEntityInRadius(float radius)
    {
        var r = radius * radius;
        foreach (var pl_pair in Player.players)
            if (v3f.Distance(pl_pair.Value.Position, Position) <= r)
                pl_pair.Value.LoadEntity(this);
    }

    public virtual void Tick() { }
}
