using System.Collections.Concurrent;
using System.Collections.Generic;

public class EntityView
{
    public ConcurrentDictionary<int, LoadedEntity<Entity>> entities = new ConcurrentDictionary<int, LoadedEntity<Entity>>();
    public ConcurrentDictionary<int, LoadedEntity<LivingEntity>> livingEntities = new ConcurrentDictionary<int, LoadedEntity<LivingEntity>>();
    public ConcurrentDictionary<int, LoadedEntity<Player>> players = new ConcurrentDictionary<int, LoadedEntity<Player>>();

    public void Add(Entity ent)
    {
        if (ent is Entity e) entities.TryAdd(e.EntityID, new LoadedEntity<Entity>(e));
        if (ent is LivingEntity l) livingEntities.TryAdd(l.EntityID, new LoadedEntity<LivingEntity>(l));
        if (ent is Player p) players.TryAdd(p.EntityID, new LoadedEntity<Player>(p));
    }
    public void Remove(IEnumerable<int> eids)
    {
        foreach (var eid in eids)
            Remove(eid);
    }
    public void Remove(int eid)
    {
        if (entities.ContainsKey(eid))
            entities.TryRemove(eid, out _);
        if (livingEntities.ContainsKey(eid))
            livingEntities.TryRemove(eid, out _);
        if (players.ContainsKey(eid))
            players.TryRemove(eid, out _);
    }
}