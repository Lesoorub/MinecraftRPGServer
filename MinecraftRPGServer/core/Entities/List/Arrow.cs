using System.Linq;
using System.Threading.Tasks;

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
        public Items.Bow SenderBow;
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
            if (Time.GetTime() - CreateTime >= Items.Bow.ArrayLifetimeMs)
            {
                Destroy();
                Dispose();
                return;
            }
            if (Physics.CheckCollisionEntitiesOverride(
                sender.world,
                sender.world.Entities
                    .Where(x => x.Value is LivingEntity l &&
                                l.EntityID != sender.EntityID)
                    .Select(x => x.Value),
                Position,
                BoxCollider,
                out var hit))
            {
                if (hit.entity != null)
                {
                    Destroy();
                    Dispose();
                    (hit.entity as LivingEntity).Health -= SenderBow.ArrowDamage;
                }
                else
                {
                    Velocity = new v3f(0, 0, 0);
                    foreach (var block in hit.blocks)
                        Particle.Spawn(sender.world, Particles.glow_squid_ink,
                            (v3f)block + new v3f(.5f, .5f, .5f), new v3f(0, 0, 0), 0, 10);
                    Task.Run(async () =>
                    {
                        skipTick = true;
                        await Task.Delay(Items.Bow.ArrayLifetimeMs);
                        Destroy();
                        Dispose();
                    });
                }

            }
            Velocity *= 0.99f;
            Velocity.y -= 0.05f;
        }
    }
}