using System.Collections.Generic;
using System.Linq;

public class LFUCache<TKey, TValue>
{

    Dictionary<TKey, LinkedListNode<CacheNode>> cache = new Dictionary<TKey, LinkedListNode<CacheNode>>();
    LinkedList<CacheNode> lfuList = new LinkedList<CacheNode>();

    class CacheNode
    {
        public TKey Key { get; set; }
        public TValue Data { get; set; }
        public int UseCount { get; set; }
    }

    int size;
    int age = 0;
    int agePolicy;
    const int default_agePolicy = 1000;

    public LFUCache(int size) : this(size, default_agePolicy)
    {
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <param name="agePolicy">after this number of gets the cache will take 1 off all UseCounts, forcing old stuff to expire.</param>
    public LFUCache(int size, int agePolicy = default_agePolicy)
    {
        this.agePolicy = agePolicy;
        this.size = size;
    }

    public void Add(TKey key, TValue val)
    {
        TValue existing;
        if (!TryGetValue(key, out existing))
        {
            var node = new CacheNode() { Key = key, Data = val, UseCount = 1 };
            if (lfuList.Count == size)
            {
                cache.Remove(lfuList.First.Value.Key);
                lfuList.RemoveFirst();
            }

            var insertionPoint = Nodes.LastOrDefault(n => n.Value.UseCount < 2);

            LinkedListNode<CacheNode> inserted;

            if (insertionPoint == null)
            {
                inserted = lfuList.AddFirst(node);
            }
            else
            {
                inserted = lfuList.AddAfter(insertionPoint, node);
            }
            cache[key] = inserted;
        }
    }

    IEnumerable<LinkedListNode<CacheNode>> Nodes
    {
        get
        {
            var node = lfuList.First;
            while (node != null)
            {
                yield return node;
                node = node.Next;
            }
        }
    }

    IEnumerable<LinkedListNode<CacheNode>> IterateFrom(LinkedListNode<CacheNode> node)
    {
        while (node != null)
        {
            yield return node;
            node = node.Next;
        }
    }

    public TValue GetOrDefault(TKey key)
    {
        TValue val;
        TryGetValue(key, out val);
        return val;
    }

    public bool TryGetValue(TKey key, out TValue val)
    {

        age++;
        if (age > agePolicy)
        {
            age = 0;
            foreach (var node in cache.Values)
            {
                var v = node.Value;
                v.UseCount--;
            }
        }

        LinkedListNode<CacheNode> data;
        bool success = false;

        if (cache.TryGetValue(key, out data))
        {
            var cacheNode = data.Value;
            val = cacheNode.Data;
            cacheNode.UseCount++;

            var insertionPoint = IterateFrom(data).Last(n => n.Value.UseCount <= cacheNode.UseCount);

            if (insertionPoint != data)
            {
                lfuList.Remove(data);
                lfuList.AddAfter(insertionPoint, data);
            }

        }
        else
        {
            val = default(TValue);
        }

        return success;
    }
}