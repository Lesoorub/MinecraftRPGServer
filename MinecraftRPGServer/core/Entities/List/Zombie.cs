using System.Collections.Generic;

namespace Entities
{
    [Entity("zombie")]
    public class Zombie : LivingEntityProtocol
    {
        public override string ID => "minecraft:zombie";
        public override v2f BoxCollider => new v2f(0.6f, 1.95f);
        public override int EntityType => 107;
        public override EntityMetadata meta { get; set; } = new ZombieMetadata();
        public Zombie(World world) : base(world) { }
    }
    [Entity("snowball")]
    public class Snowball : LivingEntityProtocol
    {
        public override string ID => "minecraft:snowball";
        public override v2f BoxCollider => new v2f(0.25f, 0.25f);
        public override int EntityType => 83;
        public override EntityMetadata meta { get; set; } = new SnowballMetadata();
        public Snowball(World world) : base(world) { }
    }
    [Entity("eye_of_ender", typeof(Custom))]
    public class EyeOfEnder  : LivingEntityProtocol
    {
        public override string ID => "minecraft:eye_of_ender";
        public override v2f BoxCollider => new v2f(0.25f, 0.25f);
        public override int EntityType => 26;
        public override EntityMetadata meta { get; set; } = new EyeOfEnderMetadata();
        public EyeOfEnder(World world) : base(world) { }

        public class Custom : CustomCommandNode
        {
            public override Node node => new Node()
            {
                Name = "eye_of_ender",
                Flags = Node.FlagsEnum.literal,  
                Childrens = new List<Node>()
                {
                    new Node()
                    {
                        Name = "item",
                        Flags = Node.FlagsEnum.argument | Node.FlagsEnum.IsExecutable,
                        Parser = Node.Parsers.item_stack
                    }
                }
            };
            public override ExecuteArgs onExecute => Execute;

            private void Execute(Entity entity, string[] args)
            {
                if (args.Length == 1 && global::Item.NameIDs.TryGetValue(args[0], out var id))
                    entity.meta["Item"] = new Slot(id, 1, null);
            }
        }
    }
}