using System;
using System.Collections.Generic;
using System.Linq;
using MineServer;
using static BossBar;
public static class BossBarManager
{
    private static Dictionary<BossBar, List<Player>> bars = new Dictionary<BossBar, List<Player>>();

    public static BossBar Create(Player player, string title, float health,
        ActionColor color = ActionColor.White,
        DivisionType division = DivisionType.NoDivision,
        FlagsType flags = FlagsType.ShouldDarkenSky) => Create(new List<Player>() { player }, title, health, color, division, flags);
    public static BossBar Create(List<Player> players, string title, float health,
        ActionColor color = ActionColor.White,
        DivisionType division = DivisionType.NoDivision,
        FlagsType flags = FlagsType.ShouldDarkenSky)
    {
        var t = new BossBar(title, health, color, division, flags);
        bars.Add(t, players);
        t.OnHealthChanged += (newhealth) =>
        {
            var bar = bars.FirstOrDefault(x => x.Key.uuid.Equals(t.uuid));
            foreach (var p in bar.Value)
                p.network.Send(new Packets.Play.BossBar()
                {
                    UUID = t.uuid,
                    Action = new Packets.Play.BossBar.UpdateHealth()
                    {
                        Health = health
                    }
                });
        };
        t.OnTitleChanged += (newtitle) =>
        {
            var bar = bars.FirstOrDefault(x => x.Key.uuid.Equals(t.uuid));
            foreach (var p in bar.Value)
                p.network.Send(new Packets.Play.BossBar()
                {
                    UUID = t.uuid,
                    Action = new Packets.Play.BossBar.UpdateTitle()
                    {
                        Title = title
                    }
                });
        };
        t.OnFlagsChanged += (newflags) =>
        {
            var bar = bars.FirstOrDefault(x => x.Key.uuid.Equals(t.uuid));
            foreach (var p in bar.Value)
                p.network.Send(new Packets.Play.BossBar()
                {
                    UUID = t.uuid,
                    Action = new Packets.Play.BossBar.UpdateFlags()
                    {
                        Flags = (byte)newflags
                    }
                });
        };
        t.OnStyleChanged += (newcolor, newdivision) =>
        {
            var bar = bars.FirstOrDefault(x => x.Key.uuid.Equals(t.uuid));
            foreach (var p in bar.Value)
                p.network.Send(new Packets.Play.BossBar()
                {
                    UUID = t.uuid,
                    Action = new Packets.Play.BossBar.UpdateStyle()
                    {
                        Color = new VarInt((int)newcolor),
                        Division = new VarInt((int)newdivision)
                    }
                });
        };
        t.OnRemove += () =>
        {
            var bar = bars.FirstOrDefault(x => x.Key.uuid.Equals(t.uuid));
            foreach (var p in bar.Value)
                p.network.Send(new Packets.Play.BossBar()
                {
                    UUID = t.uuid,
                    Action = new Packets.Play.BossBar.Remove()
                });
        };

        foreach (var p in players)
            p.network.Send(new Packets.Play.BossBar()
            {
                UUID = t.uuid,
                Action = new Packets.Play.BossBar.Add()
                {
                    Title = title,
                    Health = health,
                    Color = new VarInt((int)color),
                    Division = new VarInt((int)division),
                    Flags = flags
                }
            });
        return t;
    }

    public static void Remove(BossBar bar)
    {
        bar.Remove();
    }
}
public class BossBar
{
    public enum ActionColor : int
    {
        Pink = 0,
        Blue,
        Red,
        Green,
        Yellow,
        Purple,
        White
    }
    public enum DivisionType : int
    {
        NoDivision = 0,
        Notches_6,
        Notches_10,
        Notches_12,
        Notches_20
    }
    public enum FlagsType : byte
    {
        ShouldDarkenSky = 0x1,
        /// <summary>
        /// used to play end music
        /// </summary>
        DragonBar = 0x2,
        /// <summary>
        /// previously was also controlled by DragonBar
        /// </summary>
        CreateFog = 0x4
    }

    public Guid uuid = Guid.NewGuid();

    private string title;
    private float health;
    private ActionColor color;
    private DivisionType division;
    private FlagsType flags;

    public string Title { get => title; set { title = value; OnTitleChanged?.Invoke(value); } }
    public float Health { get => health; set { health = value; OnHealthChanged?.Invoke(value); } }
    private ActionColor Color { get => color; set { color = value; OnStyleChanged?.Invoke(color, division); } }
    private DivisionType Division { get => division; set { division = value; OnStyleChanged?.Invoke(color, division); } }
    public FlagsType Flags { get => flags; set { flags = value; OnFlagsChanged?.Invoke(flags); } }


    public delegate void TitleArgs(string title);
    public event TitleArgs OnTitleChanged;
    public delegate void HealthArgs(float health);
    public event HealthArgs OnHealthChanged;
    public delegate void StyleArgs(ActionColor color, DivisionType division);
    public event StyleArgs OnStyleChanged;
    public delegate void FlagsArgs(FlagsType Flags);
    public event FlagsArgs OnFlagsChanged;
    public delegate void RemoveArgs();
    public event RemoveArgs OnRemove;

    public BossBar(string title, float health, ActionColor color, DivisionType division, FlagsType flags)
    {
        this.title = title;
        this.health = health;
        this.color = color;
        this.division = division;
        this.flags = flags;
    }
    public void Remove()
    {
        OnRemove?.Invoke();
    }
}
