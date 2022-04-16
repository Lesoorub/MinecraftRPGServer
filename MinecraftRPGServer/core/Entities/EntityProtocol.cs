using MineServer;
using Packets.Play;

public abstract class EntityProtocol : Entity, IEntityProtocol
{
    public virtual void SendSpawn(NetworkProvider[] networks)
    {
        var t = new SpawnEntity()
        {
            EntityID = EntityID,
            Type = EntityType,
            X = Position.x,
            Y = Position.y,
            Z = Position.z,
            VelocityX = (short)(Velocity.x * 8000),
            VelocityY = (short)(Velocity.y * 8000),
            VelocityZ = (short)(Velocity.z * 8000),
            ObjectUUID = ObjectUUID,
            Pitch = new Angle(Rotation.y),
            Yaw = new Angle(Rotation.x),
            Data = Data
        };
        var m = new Packets.Play.EntityMetadata()
        {
            EntityID = EntityID,
            Metadata = meta.GetAllMetadata()
        };
        foreach (var network in networks)
        {
            network.Send(t);
            network.Send(m);
        }
    }
    public EntityProtocol(World world) : base(world) { }
}