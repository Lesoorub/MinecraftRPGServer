using System.Collections.Generic;

namespace Entities
{
    [Entity("snowball", typeof(Custom))]
    public class Snowball : EntityProtocol
    {
        public override string ID => "minecraft:snowball";
        public override v2f BoxCollider => new v2f(0.25f, 0.25f);
        public override int EntityType => 83;
        public override EntityMetadata meta { get; set; } = new SnowballMetadata();
        public Snowball(World world) : base(world) { }
        public class Custom : CustomCommandNode
        {
            public override Node node => new Node()
            {
                Name = "snowball",
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
                var itemID = ItemID.snowball;
                if (args.Length == 1 && Inventory.Item.GetItemID(args[0], out var id))
                    itemID = id;
                entity.meta["Item"] = Inventory.Item.Create(itemID, 1);
            }
        }
    }
}