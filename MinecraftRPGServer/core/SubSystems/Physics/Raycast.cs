using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftRPGServer.core.SubSystems.Physics
{
    public static class Raycast
    {
        static List<v2i> CastOnChuncks(v3f point, v3f direction, float distance, float width)
        {
            var result = new List<v2i>();

            var startChunk = point.Chunk;

            if (direction.SqrMagnitude == 0) return new List<v2i>()
            {
                point.Chunk
            };

            //TODO write logic

            return result;
        }
        public static bool AllEntitites(World world, v3f point, v3f direction, float distance, out RaycastBlockHit hit)
        {
            //float distanceSqr = distance * distance;
            //foreach (var entity in world.entities.chunks)
            //{

            //}
            hit = default;
            return false;
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

    }
}
