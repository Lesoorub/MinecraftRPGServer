using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using MineServer;
using Packets.Play;

public abstract class Entity
{
    private static int global_id = 1;

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
    public v2i ChunkPos => new v2i((int)position.x >> 4, (int)position.z >> 4);
    public v3i BlockPos => new v3i((int)position.x, (int)position.y, (int)position.z);
    protected v3f position = new v3f(0, 64, 0);
    public virtual v3f Position 
    { 
        get => position.Clone();
        set 
        { 
            var last = position.Clone(); 
            position = value.Clone(); 
            OnPositionChanged?.Invoke(last, value.Clone());
        } 
    }
    public virtual v3f Velocity { get; set; } = new v3f(0, 0, 0);
    public virtual v2f Rotation { get; set; } = new v2f(0, 0);
    public virtual EntityMetadata meta { get; set; }
    public virtual bool RotationSynchronization { get; } = true;
    public virtual bool HeadRotationSynchronization { get; } = true;
    public virtual bool TeleportSynchronization { get; } = true;
    public virtual bool PositionSynchronization { get; } = true;
    public virtual bool OnGround { get; set; } = false;
    public World world;


    public delegate void PositionChangedArgs(v3f lastposition, v3f newposition);
    public event PositionChangedArgs OnPositionChanged;
    protected void OnPositionChanged_Invoke(v3f lastposition, v3f newposition) => OnPositionChanged?.Invoke(lastposition, newposition);
    public delegate void ChunkChangedArgs(v2i lastchunk, v2i newchunk);
    public event ChunkChangedArgs OnChunkChanged;
    protected void OnChunkChanged_Invoke(v2i lastchunk, v2i newchunk) => OnChunkChanged?.Invoke(lastchunk, newchunk);
    public delegate void DestroyArgs();
    public event DestroyArgs OnDestroy;

    public Entity(World world)
    {
        this.world = world;
        while (world.entities.HasEID(global_id))
        {
            global_id++;
            global_id %= int.MaxValue - 1;
        }
        EntityID = global_id;
        meta.InitFields();
        world.entities.Add(this);
        //Реализация тригера при перемещении между чанками для корректной работы системы энтити в мире
        OnChunkChanged += Entity_OnChunkChanged;
        OnPositionChanged += Entity_OnPositionChanged;
    }

    protected void Entity_OnChunkChanged(v2i lastchunk, v2i newchunk)
    {
        world.entities.entities[EntityID] = newchunk;
        lock (world.entities.chunks)
        {
            world.entities.chunks[lastchunk].TryRemove(EntityID, out var self);
            world.entities.chunks
                .GetOrAdd(
                    newchunk,
                    new Func<v2i, ConcurrentDictionary<int, Entity>>((cpos) => new ConcurrentDictionary<int, Entity>()))
                .TryAdd(EntityID, self);
        }
    }

    protected void Entity_OnPositionChanged(v3f lastposition, v3f newposition)
    {
        var lastcpos = Chunk.FromAbsolutePosition(lastposition);
        var newcpos = Chunk.FromAbsolutePosition(newposition);
        if (!lastcpos.Equals(newcpos))
            OnChunkChanged?.Invoke(lastcpos, newcpos);
    }

    public bool isDestroyed { get; private set; } = false;

    /// <summary>
    /// Optimized
    /// </summary>
    /// <param name="radius"></param>
    /// <returns></returns>
    public IEnumerable<Entity> GetEntityInRadius(v3f position, float sqrRadius) => 
        world.entities.GetEntitiesInCircle(position, (float)Math.Sqrt(sqrRadius));
    public void Destroy()
    {
        world.entities.Remove(EntityID);
        isDestroyed = true;
        OnDestroy?.Invoke();
    }

    public void SendChangePositionAndRotation(NetworkProvider network, v3f PreviousPosition)
    {
        var deltapos = Position - PreviousPosition;
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
        }
        else
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
    }
    public void SendChangePosition(NetworkProvider network, v3f PreviousPosition)
    {
        var deltapos = Position - PreviousPosition;
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
        }
        else
        {
            network.Send(new EntityPosition()
            {
                EntityID = EntityID,
                DeltaX = (short)(deltapos.x * 4096),
                DeltaY = (short)(deltapos.y * 4096),
                DeltaZ = (short)(deltapos.z * 4096),
                OnGround = OnGround,
            });
        }
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
    
    public void ForceLoadSelfAnyPlayersInRadius(float radius)
    {
        var r = radius * radius;
        foreach (var pl_pair in Player.players)
            if (v3f.SqrDistance(pl_pair.Value.Position, Position) <= r)
                pl_pair.Value.entitiesController.LoadEntity(this);
    }

    public virtual void Tick() { }

    public static Dictionary<string, Type> EntityList = new Dictionary<string, Type>();
    public static void InitEntities()
    {
        foreach (var ent_type in RPGServer.GetTypesWithAttribute<EntityAttribute>())
        {
            EntityList.Add(ent_type.GetCustomAttribute<EntityAttribute>().nameid, ent_type);
        }
    }
}
