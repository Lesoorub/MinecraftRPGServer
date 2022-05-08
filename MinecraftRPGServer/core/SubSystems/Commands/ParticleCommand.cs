using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ChatCommand]
public class ParticleCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "particle",
            Flags = Node.FlagsEnum.literal,
            Childrens = new List<Node>()
            {
                new Node()
                {
                    Name = "all",
                    Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
                    Childrens = new List<Node>()
                    {
                        new Node()
                        {
                            Name = "duration",
                            Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                            Parser = Node.Parsers.integer,
                            Properties = new Node.Parsers.IntegerParser(Node.Parsers.IntegerParser.FlagsEnum.Min)
                            {
                                Min = 0
                            }
                        }
                    }
                },
                new Node()
                {
                    Name = "spawn",
                    Flags = Node.FlagsEnum.literal,
                    Childrens = new List<Node>()
                    {
                        new Node()
                        {
                            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
                            Name = "ID",
                            Childrens = 
                                Enum.GetNames(typeof(Particles))
                                .Where(x => !ignore.Contains((int)(Particles)Enum.Parse(typeof(Particles), x)))
                                .Select(x => new Node()
                                {
                                    Name = x,
                                    Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
                                })
                                .ToList()
                        }
                    }
                }
            }
        }, Execute);
    }
    readonly int[] ignore = new int[] { 2, 3, 14, 15, 17, 22, 23, 24, 30, 35, 36 };
    void Execute(Player player, string[] args)
    {
        if (args.Length >= 1 && args[0] == "all")
        {
            Task.Factory.StartNew(async () =>
            {
                if (!int.TryParse(args[1], out var duration))
                    return;
                Particles[] allPossibleParticles = ((int[])Enum.GetValues(typeof(Particles)))
                    .Where(x => !ignore.Contains(x))
                    .Select(x => (Particles)x).ToArray();
                string[] names = Enum.GetNames(typeof(Particles));

                const float radius = 10;

                var position = player.Position.Clone();
                Dictionary<Particles, Hologram> holograms = new Dictionary<Particles, Hologram>();

                for (int i = 0; i < 10 * duration; i++)
                {
                    for (float k = 0; k < allPossibleParticles.Length; k++)
                    {
                        var particleID = allPossibleParticles[(int)k];
                        float angle = k / allPossibleParticles.Length;
                        var pos = position + new v3f(
                                (float)Math.Sin(angle * Math.PI * 2) * radius,
                                1 + (k % 3),
                                (float)Math.Cos(angle * Math.PI * 2) * radius);

                        Particle.Spawn(
                            world: player.world,
                            id: particleID,
                            position: pos,
                            offset: v3f.one / 5,
                            data: 0,
                            count: 1);

                        if (i == 0)
                            holograms.Add(particleID, Hologram.Create(player.world, pos + v3f.up, names[(int)particleID]));
                    }
                    await Task.Delay(100);
                }
                foreach (var h in holograms)
                    h.Value.Destroy();
            });
        }
        if (args.Length == 2 && args[0] == "spawn")
        {

        }
    }
}
