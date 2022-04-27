﻿using System.Collections.Generic;

namespace Entities
{
    [Entity("eye_of_ender", typeof(Custom))]
    public class EyeOfEnder : EntityProtocol
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
                int id = -1;
                if (args.Length == 1 && global::Item.NameIDs.TryGetValue(args[0], out var _id))
                    id = _id;
                if (id == -1)
                    id = global::Item.NameIDs["minecraft:ender_pearl"];
                entity.meta["Item"] = new Slot(id, 1, null);
            }
        }
    }
}