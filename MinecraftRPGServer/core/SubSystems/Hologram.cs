using System.Collections.Concurrent;

public class Hologram
{
    public int ID => entity.EntityID;
    private Entities.ArmorStand entity;
    private string text;
    public string Text { get => text; set => SetText(value); }
    public v3f Position
    {
        get => entity.Position;
        set => entity.Position = value - v3f.up * 0.9875f;
    }
    public Hologram(World world, v3f position, string text)
    {
        entity = new Entities.ArmorStand(world)
        {
            Position = position - v3f.up * 0.9875f,
        };
        entity.meta.SetFlag("entityStatus", (byte)EntityMetadata.EntityStatus.IsInvisible);
        entity.meta.SetFlag("armorStandStatus", (byte)ArmorStandMetadata.ArmorStandStatus.isSmall);
        SetText(text);
    }

    public void SetText(string text)
    {
        entity.meta["CustomName"] = new Chat?(Chat.ColoredText(text));
        entity.meta["isCustomNameVisible"] = true;
        this.text = text;
    }
    public void Destroy()
    {
        list.TryRemove(entity.EntityID, out _);
        entity.Destroy();
    }

    public static ConcurrentDictionary<int, Hologram> list = new ConcurrentDictionary<int, Hologram>();
    public static Hologram Create(World world, v3f position, string text)
    {
        var h = new Hologram(world, position, text);
        list.TryAdd(h.entity.EntityID, h);
        return h;
    }
    public static void Destroy(int ID)
    {
        if (list.TryGetValue(ID, out var h)) 
            h.Destroy();
    }
}
