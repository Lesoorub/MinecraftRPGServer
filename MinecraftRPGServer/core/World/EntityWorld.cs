using System;
using System.Collections;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class EntityWorld
{
    private class v2iComparer : IEqualityComparer<v2i>
    {
        public bool Equals(v2i x, v2i y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null) return x.Equals(y);
            return false;
        }

        public int GetHashCode(v2i obj)
        {
            return obj.GetHashCode();
        }
    }
    public ConcurrentDictionary<int, v2i> entities = 
        new ConcurrentDictionary<int, v2i>();
    public ConcurrentDictionary<v2i, ConcurrentDictionary<int, Entity>> chunks = 
        new ConcurrentDictionary<v2i, ConcurrentDictionary<int, Entity>>(new v2iComparer());
    public void Add(Entity entity)
    {
        var eid = entity.EntityID;
        var cpos = entity.ChunkPos;
        entities.TryAdd(eid, cpos);
        Console.WriteLine($"Create entity EID={eid}, cpos={cpos}");
        if (!chunks.ContainsKey(cpos))
        {
            chunks.TryAdd(cpos, new ConcurrentDictionary<int, Entity>(new KeyValuePair<int, Entity>[]
            {
                new KeyValuePair<int, Entity>(eid, entity)
            }));
            return;
        }
        else if (chunks.TryGetValue(cpos, out var list))
            list.TryAdd(eid, entity);
        else throw new Exception("Что-то пошло не так");
    }

    public void Remove(int EID)
    {
        if (entities.TryRemove(EID, out var cpos) &&
            chunks.TryGetValue(cpos, out var dict))
        {
            Console.WriteLine($"Remove entity EID={EID}, cpos={cpos}");
            dict.TryRemove(EID, out var entity);
        }
        else
            throw new Exception("Try remove unknown entity?");
    }
    public bool HasEID(int EID) => entities.ContainsKey(EID);
    public Entity GetByEID(int EntityID) => 
        entities.TryGetValue(EntityID, out var cpos) && 
        chunks.TryGetValue(cpos, out var list) && 
        list.TryGetValue(EntityID, out var entity)
        ? entity : null;
    public List<Entity> GetEntitiesInCircle(v3f position, float radius)
    {
        var result = new List<Entity>();
        var cpos = Chunk.FromAbsolutePosition(position);
        var crad = (int)Math.Ceiling(radius / 16f);
        var sqrRad = radius * radius;

        for (int x = cpos.x - crad; x <= cpos.x + crad; x++)
            for (int y = cpos.y - crad; y <= cpos.y + crad; y++)
            {
                if (!chunks.TryGetValue(new v2i(x, y), out var list)) continue;
                result.AddRange(list
                    .Where(item => v3f.SqrDistance(item.Value.Position, position) <= sqrRad)
                    .Select(item => item.Value));
            }

        return result;
    }
}