using System;
using System.Collections.Generic;
using System.Linq;
using static Chat._hoverEvent;

namespace MinecraftRPGServer.core.SubSystems.Physics
{
    /// <summary>
    /// Реализует методы 
    /// </summary>
    public static class Raycast
    {
        /// <summary>
        /// Минимальное значение на которое два числа должны отличаться
        /// </summary>
        const float epsilon = 1e-4f;
        /// <summary>
        /// Функция возвращающая все пройденные лучем ячейки двухмерной сетки
        /// </summary>
        /// <param name="start">Начало луча</param>
        /// <param name="dir">Направление луча</param>
        /// <param name="distance">Дальность</param>
        /// <param name="width">Ширина</param>
        /// <returns>Список пройденных лучем координат</returns>
        static List<v2i> Raycast2DField(v2f start, v2f dir, float distance, float width = 1)
        {
            List<v2i> line = new List<v2i>();

            width = Math.Max(width, 1);
            distance = Math.Max(distance, 1);

            var end = new v2f(
                (float)Math.Round(start.x + dir.x * distance),
                (float)Math.Round(start.y + dir.y * distance));

            v2i min = new v2f((float)Math.Min(start.x, end.x) - width, (float)Math.Min(start.y, end.y) - width).RoundToInt;
            v2i max = new v2f((float)Math.Max(start.x, end.x) + width, (float)Math.Max(start.y, end.y) + width).RoundToInt;

            for (int x = min.x; x <= max.x; x++)
                for (int y = min.y; y <= max.y; y++)
                {
                    var point = new v2f(x, y);
                    var proj = v2f.Project(point - start, dir);
                    var projection = proj + start;
                    var sqrPoint_to_projection = v2f.SqrDistance(point, projection);
                    if (sqrPoint_to_projection <= width * width)
                    {
                        var sum = proj.Magnitude + v2f.Distance(proj, (dir * distance));
                        const float epsilon = 1e-4f;
                        if (sum + epsilon >= distance &&
                            sum - epsilon <= distance)
                            line.Add(point.RoundToInt);
                    }
                }

            if (!line.Any(z => z.Equals(start.RoundToInt)))
            {
                line.Add(start.RoundToInt);
            }

            if (!line.Any(z => z.Equals(end.RoundToInt)))
            {
                line.Add(end.RoundToInt);
            }

            return line;
        }
        /// <summary>
        /// Возвращает координаты всех чанков пройденных лучем
        /// </summary>
        /// <param name="point">Абсолюдные координаты начальной точки</param>
        /// <param name="direction">Направление</param>
        /// <param name="distance">Абсолюдная дистанция</param>
        /// <param name="width">Абсолюдная ширина</param>
        /// <returns>Список координат чанков пройденных лучем</returns>
        static List<v2i> GetChunks(v3f point, v3f direction, float distance, float width)
        {
            v2i chunk = World.GetChunkFromCoords(point);
            float ycoef = (float)Math.Cos(direction.y * Math.PI * 2);
            v2f horizontalDir = new v2f(direction.x * ycoef, direction.z * ycoef).Normalized;

            if (horizontalDir.SqrMagnitude <= epsilon * epsilon) 
                return new List<v2i>()
                {
                     chunk
                };

            const int chunk_size = 16;
            return Raycast2DField(
                start: (v2f)chunk,
                dir: horizontalDir,
                distance: (distance * ycoef) / chunk_size,
                width: width / chunk_size);
        }
        static IEnumerable<Entity> GetEntities(EntityWorld world, v3f point, v3f direction, float distance, float width)
        {
            return GetChunks(point, direction, distance, width)
                .SelectMany(x => world.chunks.TryGetValue(x, out var val) ? val.Values : new Entity[0]);
        }

        static bool PointOnLine(v3f from, v3f to, v3f point)
        {
            float ideal_distance = v3f.SqrDistance(from, to);
            float real_distance = v3f.SqrDistance(from, point) + v3f.SqrDistance(point, to);
            return real_distance < ideal_distance + epsilon && real_distance > ideal_distance - epsilon;
        }
        static v3f LineIntersection(v3f A1, v3f A2, v3f B1, v3f B2)
        {
            float xo = A1.x, yo = A1.y, zo = A1.z;
            float p = A2.x - A1.x, q = A2.y - A1.y, r = A2.z - A1.z;

            float x1 = B1.x, y1 = B1.y, z1 = B1.z;
            float p1 = B2.x - B1.x, q1 = B2.y - B1.y, r1 = B2.z - B1.z;

            float x = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) /
                (q * p1 - q1 * p);
            float y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) /
                (p * q1 - p1 * q);
            float z = (zo * q * r1 - z1 * q1 * r - yo * r * r1 + y1 * r * r1) /
                (q * r1 - q1 * r);

            var point = new v3f(x, y, z);
            if (PointOnLine(A1, A2, point) && 
                PointOnLine(B1, B2, point))
                return point;
            return null;
        }
        public static int AllEntitites(
            World world, 
            v3f point, 
            v3f direction,
            float distance, 
            ref RaycastEntityHit[] hit)
        {
            float sqrDistance = distance * distance;


            int count = 0;
            foreach (var entity in GetEntities(world.entities, point, direction, distance, 0))
            {
                Console.WriteLine($"id={entity.ID}");
                var delta = entity.Position - point;
                var projection = v3f.Project(delta, direction);
                float sqrDistanceToProjection = projection.SqrMagnitude;

                //Быстрая проверка на расстояние
                if (sqrDistanceToProjection > sqrDistance)
                {
                    Console.WriteLine("Быстрая проверка на расстояние");
                    continue;
                }
                var DistanceToProjection = (float)Math.Sqrt(sqrDistanceToProjection);
                //Менее быстрая проверка на нахождение на линии от point в направлении direction
                var sumDistance = DistanceToProjection + v3f.Distance(projection, direction * distance);
                if (sumDistance > distance + epsilon ||
                    sumDistance < distance - epsilon)
                {
                    Console.WriteLine("Менее быстрая проверка на нахождение на линии от point в направлении direction");
                    continue;
                }
                //Медленная проверка на пересечение
                if (!Physics.EntityIntersectionWithPoint(entity, projection + point))
                {
                    Console.WriteLine("Медленная проверка на пересечение");
                    continue;
                }


                if (entity.EntityType != 111)
                    Particle.Spawn(world, Particles.electric_spark, projection + point, v3f.zero, 0, 1);

                hit[count++] = new RaycastEntityHit(
                    entity: entity,
                    distance: DistanceToProjection,
                    point: projection + point);

                if (hit.Length == count)
                    break;
            }
            return count;
        }
        public static bool Block(World world, v3f point, v3f direction, float distance, out RaycastBlockHit hit)
        {
            float distanceSqr = distance * distance;
            /*
            result = new List<CircleCollider>();
            float distanceSqr = distance * distance;
            foreach (var layer in layers)
            {
                if (!allColliders.TryGetValue(layer, out List<CircleCollider> colliders))
                    continue;
                foreach (var collider in colliders)
                {
                    var deltaX = collider.X - x;
                    var deltaY = collider.Y - y;

                    var (projectX, projectY) = VectorHelper.Project(deltaX, deltaY, dirX, dirY);

                    //Проверка на дальность
                    float distanceToProjectionSqr = VectorHelper.MagnitudeSqr(projectX, projectY);
                    if (distanceToProjectionSqr > distanceSqr)
                        continue;

                    //Проверка на то что объект находится по направлению луча, а не позади
                    //Сумма дистанций от начала луча до проекции и от проекции до конца луча
                    var sumDistance = distanceToProjectionSqr +
                        VectorHelper.DistanceSqr(projectX, projectY, dirX * distance, dirY * distance);
                    const float epsilon = 1e-6f;//Введем эпсилон чтобы не попасть на случайную неточность
                    if (sumDistance - epsilon <= distanceSqr &&
                        sumDistance + epsilon >= distanceSqr)
                        continue;

                    //Рассчет дистанции от точки проекции до объекта
                    var distanceSqrFromProjectionToCollider = VectorHelper.DistanceSqr(projectX, projectY, deltaX, deltaY);
                    if (distanceSqrFromProjectionToCollider > width + collider.Radius)
                        continue;

                    result.Add(collider);
                }
            }
            return result.Count > 0;
             */
            hit = default;
            return false;
        }
    }
    public struct RaycastBlockHit
    {
        public readonly BlockState block;
        public readonly float distance;
        public readonly v3f point;

        public RaycastBlockHit(BlockState block, float distance, v3f point)
        {
            this.block = block;
            this.distance = distance;
            this.point = point;
        }
    }
    public struct RaycastEntityHit
    {
        public readonly Entity Entity;
        public readonly float distance;
        public readonly v3f point;

        public RaycastEntityHit(Entity entity, float distance, v3f point)
        {
            Entity = entity;
            this.distance = distance;
            this.point = point;
        }
    }
}
