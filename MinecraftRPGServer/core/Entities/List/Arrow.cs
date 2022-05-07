using System.Linq;
using System.Threading.Tasks;
using Collision;

namespace Entities
{
    public class Arrow : EntityProtocol
    {
        public override string ID => "minecraf:arrow";
        public override v2f BoxCollider => new v2f(.5f, .5f);
        public override int EntityType => 2;
        public override EntityMetadata meta { get; set; } = new ArrowMetadata();

        public override bool RotationSynchronization => false;
        public override bool HeadRotationSynchronization => false;
        public override bool TeleportSynchronization => false;
        public override bool PositionSynchronization => false;
        public Inventory.Items.Bow SenderBow;
        public Player sender;
        bool skipTick = false;
        long CreateTime;
        public Arrow(World world) : base(world)
        {
            CreateTime = Time.GetTime();
        }
        public override void Tick()
        {
            if (skipTick) return;
            //Уничтожить если превышено время жизни
            if (Time.GetTime() - CreateTime >= Inventory.Items.Bow.ArrayLifetimeMs)
            {
                Destroy();
                return;
            }
            //А не будет ли этот метод просчитывать чужие стрелы несколько раз?
            if (Physics.CheckCollisionEntitiesOverride(
                sender.world,
                sender.view.livingEntities
                    .Where(l => l.Key != sender.EntityID)
                    .Select(x => x.Value.entity),
                Position,
                BoxCollider,
                out var hit))
            {
                if (hit.entity != null)
                {
                    if (hit.entity is LivingEntity t)
                        t.Health -= SenderBow.ArrowDamage;
                    //Уничтожить при попадании в энтити
                    Destroy();
                    sender.SendArrayHitSound();
                }
                else
                {
                    Velocity = new v3f(0, 0, 0);
                    foreach (var block in hit.blocks)
                        Particle.Spawn(sender.world, Particles.glow_squid_ink,
                            (v3f)block + new v3f(.5f, .5f, .5f), new v3f(0, 0, 0), 0, 10);
                    CreateTime = Time.GetTime();
                }

            }
            Velocity *= 0.99f;
            Velocity.y -= 0.05f;
        }
    }
}