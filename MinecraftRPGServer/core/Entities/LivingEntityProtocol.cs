using MineServer;
using Packets.Play;

public class LivingEntityProtocol : LivingEntity, IEntityProtocol
{
    public virtual void SendSpawn(NetworkProvider[] networks)
    {
        var t = new SpawnLivingEntity()
        {
            EntityID = EntityID,
            EntityUUID = EntityUUID,
            Type = EntityType,
            X = Position.x,
            Y = Position.y,
            Z = Position.z,
            Yaw = new Angle(Rotation.x),
            Pitch = new Angle(Rotation.y),
            HeadYaw = new Angle(HeadYaw),
            VelocityX = (short)(Velocity.x * 8000),
            VelocityY = (short)(Velocity.y * 8000),
            VelocityZ = (short)(Velocity.z * 8000),
        };
        foreach (var network in networks)
            network.Send(t);
    }
    public LivingEntityProtocol(World world) : base(world) { }
}