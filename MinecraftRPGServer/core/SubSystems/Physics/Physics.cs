using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MinecraftRPGServer.core.SubSystems.Physics
{
    public static class Physics
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Intersection(v3f a_pos, v2f a_size, v3f b_pos, v2f b_size)
        {
            box box1 = new box(a_pos, new v3f(a_size.x, a_size.y, a_size.x));
            box box2 = new box(b_pos, new v3f(b_size.x, b_size.y, b_size.x));
            return
                isOverlapping1D(box1.x, box2.x) &&
                isOverlapping1D(box1.y, box2.y) &&
                isOverlapping1D(box1.z, box2.z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IntersectionWithCube(v3f a_pos, v2f a_size, v3i cube_pos)
        {
            box box1 = new box(a_pos, new v3f(a_size.x, a_size.y, a_size.x));
            return
                isOverlapping1D(box1.x, cube_pos.x) &&
                isOverlapping1D(box1.y, cube_pos.y) &&
                isOverlapping1D(box1.z, cube_pos.z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IntersectionWithCube(v3f a_pos, v3f a_size, v3i cube_pos)
        {
            box box1 = new box(a_pos, a_size);
            return
                isOverlapping1D(box1.x, cube_pos.x) &&
                isOverlapping1D(box1.y, cube_pos.y) &&
                isOverlapping1D(box1.z, cube_pos.z);
        }
        public static bool CheckCollisionEntitiesOverride(ICollisionProvider world, IEnumerable<Entity> entities, v3f a_pos, v2f a_size, out Hit hit)
        {
            v3i[] collidedBlocks = new v3i[27];
            if (IntersectionWithBlock(world, a_pos, a_size, ref collidedBlocks, out var len))
            {
                hit = new Hit(collidedBlocks.Take(len).ToArray(), null);
                return true;
            }
            foreach (var e in entities)
                if (Intersection(a_pos, a_size, e.Position, e.BoxCollider))
                {
                    hit = new Hit(null, e);
                    return true;
                }
            hit = default;
            return false;
        }
        public static int GetVolumeInBlocks(v3f a_pos, v2f a_size)
        {
            int f(float x) => (int)Math.Floor(x);
            return
                (f(a_pos.x + a_size.x) - f(a_pos.x - a_size.x)) *
                (f(a_pos.y + a_size.y) - f(a_pos.y - a_size.y)) *
                (f(a_pos.z + a_size.x) - f(a_pos.z - a_size.x));
        }
        public static int GetMaxVolumeInBlocks(v2f a_size)
        {
            int f(float x) => (int)Math.Ceiling(x) + 1;
            return
                f(a_size.x) *
                f(a_size.y) *
                f(a_size.x);
        }
        public static bool IntersectionWithBlock(ICollisionProvider world, v3f a_pos, v3f a_size, ref v3i[] collidedBlocks, out int len)
        {
            v3i t = new v3i((int)Math.Round(a_pos.x), (int)Math.Round(a_pos.y), (int)Math.Round(a_pos.z));
            int f(float x) => (int)Math.Floor(x);
            len = 0;
            for (int x = f(t.x - a_size.x); x <= f(t.x + a_size.x); x++)
                for (int y = f(t.y - a_size.y); y <= f(t.y + a_size.y); y++)
                    for (int z = f(t.z - a_size.z); z <= f(t.z + a_size.z); z++)
                    {
                        var loc = new v3i(x, y, z);
                        if (world.HasCollision(loc) && IntersectionWithCube(a_pos, a_size, loc))
                        {
                            collidedBlocks[len++] = loc;
                        }
                    }
            return len != 0;
        }
        public static bool IntersectionWithBlock(ICollisionProvider world, v3f a_pos, v2f a_size, ref v3i[] collidedBlocks, out int len)
        {
            v3i t = new v3i((int)Math.Round(a_pos.x), (int)Math.Round(a_pos.y), (int)Math.Round(a_pos.z));
            int f(float x) => (int)Math.Floor(x);
            len = 0;
            for (int x = f(t.x - a_size.x); x <= f(t.x + a_size.x); x++)
                for (int y = f(t.y - a_size.y); y <= f(t.y + a_size.y); y++)
                    for (int z = f(t.z - a_size.x); z <= f(t.z + a_size.x); z++)
                    {
                        var loc = new v3i(x, y, z);
                        if (world.HasCollision(loc) && IntersectionWithCube(a_pos, a_size, loc))
                        {
                            collidedBlocks[len++] = loc;
                        }
                    }
            return len != 0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool isOverlapping1D(bound a, float b) => a.max >= b && b >= a.min;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool isOverlapping1D(bound a, bound b) => a.max >= b.min && b.max >= a.min;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool isOverlapping1D(bound a, int unit_cube_center) => a.max >= unit_cube_center - 0.5f && unit_cube_center + 0.5f >= a.min;

        public static bool EntityIntersectionWithPoint(Entity entity, v3f point)
        {
            box collisionBox = new box(entity.Position + v3f.up * entity.BoxCollider.y / 2, new v3f(entity.BoxCollider.x, entity.BoxCollider.y, entity.BoxCollider.x));
            return
                isOverlapping1D(collisionBox.x, point.x) &&
                isOverlapping1D(collisionBox.y, point.y) &&
                isOverlapping1D(collisionBox.z, point.z);
        }


        struct bound
        {
            public readonly float min;
            public readonly float max;

            public bound(float center, float size)
            {
                min = center - size / 2;
                max = center + size / 2;
            }
        }

        struct box
        {
            public readonly bound x;
            public readonly bound y;
            public readonly bound z;

            public box(v3f center, v3f size)
            {
                x = new bound(center.x, size.x);
                y = new bound(center.y, size.y);
                z = new bound(center.z, size.z);
            }
        }

        public struct Hit
        {
            public v3i[] blocks;
            public Entity entity;

            public Hit(v3i[] blocks, Entity entity)
            {
                this.blocks = blocks;
                this.entity = entity;
            }
        }
    }

    namespace Collision
    {
        public static class EntityPhysics
        {
            public static void CalcCollisions(Entity target, IEnumerable<Entity> entities)
            {
                var target_aabb = new AABB(target.Position, new v3f(target.BoxCollider.x, target.BoxCollider.y, target.BoxCollider.x));
                //foreach (var aabb in Physics.CollidedWith(
                //    target_aabb,
                //    entities.Select(x => 
                //        new AABB(x.Position, new v3f(x.BoxCollider.x, x.BoxCollider.y, x.BoxCollider.x)))))
                //{
                //    target.Position += (target.Position - aabb.center) * 0.05f;
                //}
                v3i[] blocks = new v3i[4];
                if (Physics.CollidedWithWorld(target_aabb, target.world, out var len, ref blocks))
                {
                    for (int k = 0; k < len; k++)
                    {
                        var block = blocks[k];
                        if (block.y + 1 > target_aabb.min.y)
                        {
                            target.Position.y = block.y + 1;
                            target.Velocity.y = 0;
                        }
                    }
                }
            }
            public static void CalcCollisions(Entity target)
            {
                throw new NotImplementedException();
                World w = target.world;

                float sign(float x) => Math.Min(Math.Max(x, -1), 1);
                v3f GetNormal(v3f point, v3i block) => new v3f(
                        sign(point.x - (block.x + 0.5f)),
                        sign(point.y - (block.y + 0.5f)),
                        sign(point.z - (block.z + 0.5f)));

                //var p = target.Position;
                var c = target.BoxCollider;
                //v3f min = new v3f(
                //    p.x - c.x / 2,
                //    p.y - c.y / 2,
                //    p.z - c.x / 2);
                //v3f max = new v3f(
                //    p.x + c.x / 2,
                //    p.y + c.y / 2,
                //    p.z + c.x / 2);
                AABB aabb = new AABB(target.Position, new v3f(c.x, c.y, c.x));
                Particle.Spawn(target.world, Particles.crit, target.Position, v3f.zero, 0, 1);
                for (int x = (int)aabb.min.x; x <= aabb.max.x; x++)
                    for (int y = (int)aabb.min.y; y <= aabb.max.y; y++)
                        for (int z = (int)aabb.min.z; z <= aabb.max.z; z++)
                        {
                            var loc = new v3i(x, y, z);
                            Particle.Spawn(target.world, Particles.flame, (v3f)loc + v3f.halfone, v3f.zero, 0, 1);

                            if (w.GetBlock(loc).haveCollision &&
                                AABB.Intersection(aabb, loc))
                            {
                                Particle.Spawn(target.world, Particles.glow, (v3f)loc + v3f.halfone, v3f.zero, 0, 1);
                                if (loc.Equals(target.BlockPos))
                                {
                                    target.Position.y = y + 1 + c.y / 2;
                                    target.Velocity = v3f.zero;
                                    break;
                                }
                                var normal = GetNormal(target.Position, loc);
                                break;
                            }
                        }
            }
        }

        public static class Physics
        {
            public static void CollidedWith(AABB a, IEnumerable<AABB> b, Action<AABB> OnCollided)
            {
                foreach (var el in b)
                    if (AABB.Intersection(a, el))
                        OnCollided(el);
            }
            public static bool CollidedWithWorld(AABB a, World world, out int len, ref v3i[] blocks)
            {
                len = 0;
                for (int x = (int)a.min.x; x <= (int)a.max.x; x++)
                    for (int y = (int)a.min.y; y <= (int)a.max.y; y++)
                        for (int z = (int)a.min.z; z <= (int)a.max.z; z++)
                        {
                            var loc = new v3i(x, y, z);
                            if (world.GetBlock(loc).haveCollision &&
                                AABB.Intersection(a, loc))
                                blocks[len++] = loc;
                        }
                return len != 0;
            }
        }
        public struct AABB
        {
            public v3f min;
            public v3f max;

            public v3f center => (min + max) / 2;
            public v3f size => max - min;

            public AABB(v3f center, v3f size)
            {
                min = center - size / 2;
                max = center + size / 2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool Intersection(AABB a, AABB b) =>
                a.max.x >= b.min.x && b.max.x >= a.min.x &&
                a.max.y >= b.min.y && b.max.y >= a.min.y &&
                a.max.z >= b.min.z && b.max.z >= a.min.z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool Intersection(AABB a, v3i b) =>
                a.max.x >= b.x && b.x + 1 >= a.min.x &&
                a.max.y >= b.y && b.y + 1 >= a.min.y &&
                a.max.z >= b.z && b.z + 1 >= a.min.z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool isOverlapping1D(float a_min, float a_max, float b_min, float b_max) => a_max >= b_min && b_max >= a_min;
        }
    }
}
