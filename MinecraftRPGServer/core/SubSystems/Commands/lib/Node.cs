using System;
using System.Linq;
using System.Collections.Generic;
using MineServer;
using NBT;

public class Node : ISerializable
{
    [Flags]
    public enum FlagsEnum : byte
    {
        root = 0,
        literal = 1,
        argument = 2,
        IsExecutable = 0x4,
        HasRedirect = 0x8,
        HasSuggestionsType = 0x10
    }
    public int index = -1;
    public FlagsEnum Flags;
    public int ChildrenCount { get => Childrens != null ? Childrens.Count : 0; }
    public List<Node> Childrens = new List<Node>();
    //Optional
    public Node RedirectNode;//Only if Flags.HasRedirect
    public string Name;//Only if Flags is 1 or 2
    public string Parser;//Only if Flag is 2
    public ParserProp Properties;//Only if Flag is 2
    public string SuggestionsType;//Only if Flags.HasSuggestionsType

    public static class Parsers
    {
        public readonly static string @bool              = "brigadier:bool";
        public readonly static string @double            = "brigadier:double";
        public readonly static string @float             = "brigadier:float";
        public readonly static string integer            = "brigadier:integer";
        public readonly static string @long              = "brigadier:long";
        public readonly static string @string            = "brigadier:string";
        public readonly static string entity             = "minecraft:entity";
        public readonly static string game_profile       = "minecraft:game_profile";
        public readonly static string block_pos          = "minecraft:block_pos";
        public readonly static string column_pos         = "minecraft:column_pos";
        public readonly static string vec3               = "minecraft:vec3";
        public readonly static string vec2               = "minecraft:vec2";
        public readonly static string block_state        = "minecraft:block_state";
        public readonly static string block_predicate    = "minecraft:block_predicate";
        public readonly static string item_stack         = "minecraft:item_stack";
        public readonly static string item_predicate     = "minecraft:item_predicate";
        public readonly static string color              = "minecraft:color";
        public readonly static string component          = "minecraft:component";
        public readonly static string message            = "minecraft:message";
        public readonly static string nbt                = "minecraft:nbt";
        public readonly static string nbt_path           = "minecraft:nbt_path";
        public readonly static string objective          = "minecraft:objective";
        public readonly static string objective_criteria = "minecraft:objective_criteria";
        public readonly static string operation          = "minecraft:operation";
        public readonly static string particle           = "minecraft:particle";
        public readonly static string rotation           = "minecraft:rotation";
        public readonly static string angle              = "minecraft:angle";
        public readonly static string scoreboard_slot    = "minecraft:scoreboard_slot";
        public readonly static string score_holder       = "minecraft:score_holder";
        public readonly static string swizzle            = "minecraft:swizzle";
        public readonly static string team               = "minecraft:team";
        public readonly static string item_slot          = "minecraft:item_slot";
        public readonly static string resource_location  = "minecraft:resource_location";
        public readonly static string mob_effect         = "minecraft:mob_effect";
        public readonly static string function           = "minecraft:function";
        public readonly static string entity_anchor      = "minecraft:entity_anchor";
        public readonly static string range              = "minecraft:range";
        public readonly static string int_range          = "minecraft:int_range";
        public readonly static string float_range        = "minecraft:float_range";
        public readonly static string item_enchantment   = "minecraft:item_enchantment";
        public readonly static string entity_summon      = "minecraft:entity_summon";
        public readonly static string dimension          = "minecraft:dimension";
        public readonly static string uuid               = "minecraft:uuid";
        public readonly static string nbt_tag            = "minecraft:nbt_tag";
        public readonly static string nbt_compound_tag   = "minecraft:nbt_compound_tag";
        public readonly static string time               = "minecraft:time";
        //public readonly static string modid              = "forge:modid";
        //public readonly static string @enum              = "forge:enum";

        public class DoubleParser : ParserProp
        {
            [Flags]
            public enum FlagsEnum : byte
            {
                Min = 0x01, Max = 0x02
            }
            public FlagsEnum Flags;
            public double Min;
            public double Max;

            public DoubleParser(FlagsEnum flags)
            {
                Flags = flags;
            }
            public override byte[] ToByteArray()
            {
                var writer = new ArrayWriter(true);
                writer.Write((byte)Flags);

                if (Flags.HasFlag(FlagsEnum.Min))
                    writer.Write(Min);
                if (Flags.HasFlag(FlagsEnum.Max))
                    writer.Write(Max);

                return writer.ToArray();
            }
        }
        public class FloatParser : ParserProp
        {
            [Flags]
            public enum FlagsEnum : byte
            {
                Min = 0x01, Max = 0x02
            }
            public FlagsEnum Flags;
            public float Min;
            public float Max;

            public FloatParser(FlagsEnum flags)
            {
                Flags = flags;
            }

            public override byte[] ToByteArray()
            {
                var writer = new ArrayWriter(true);
                writer.Write((byte)Flags);

                if (Flags.HasFlag(FlagsEnum.Min))
                    writer.Write(Min);
                if (Flags.HasFlag(FlagsEnum.Max))
                    writer.Write(Max);

                return writer.ToArray();
            }
        }
        public class IntegerParser : ParserProp
        {
            [Flags]
            public enum FlagsEnum : byte
            {
                None = 0, Min = 0x01, Max = 0x02
            }
            public FlagsEnum Flags;
            public int Min;
            public int Max;

            public IntegerParser(FlagsEnum flags)
            {
                Flags = flags;
            }

            public override byte[] ToByteArray()
            {
                var writer = new ArrayWriter(true);
                writer.Write((byte)Flags);

                if (Flags.HasFlag(FlagsEnum.Min))
                    writer.Write(Min);
                if (Flags.HasFlag(FlagsEnum.Max))
                    writer.Write(Max);

                return writer.ToArray();
            }
        }
        public class LongParser : ParserProp
        {
            [Flags]
            public enum FlagsEnum : byte
            {
                Min = 0x01, Max = 0x02
            }
            public FlagsEnum Flags;
            public long Min;
            public long Max;

            public LongParser(FlagsEnum flags)
            {
                Flags = flags;
            }

            public override byte[] ToByteArray()
            {
                var writer = new ArrayWriter(true);
                writer.Write((byte)Flags);

                if (Flags.HasFlag(FlagsEnum.Min))
                    writer.Write(Min);
                if (Flags.HasFlag(FlagsEnum.Max))
                    writer.Write(Max);

                return writer.ToArray();
            }
        }
        public class StringParser : ParserProp
        {
            public enum State : byte
            {
                SINGLE_WORD = 0, QUOTABLE_PHRASE = 1, GREEDY_PHRASE = 2
            }
            public State state;

            public StringParser(State state)
            {
                this.state = state;
            }

            public override byte[] ToByteArray() => new byte[] { (byte)state };
        }
        public class EntityParser : ParserProp
        {
            public enum State : byte
            {
                single = 1, Multiply = 2
            }
            public State state;

            public EntityParser(State state)
            {
                this.state = state;
            }

            public override byte[] ToByteArray() => new byte[] { (byte)state };
        }
        public class ScoreHolderParser : ParserProp
        {
            public enum State : byte
            {
                AllowMultiply = 1
            }
            public State state;

            public ScoreHolderParser(State state)
            {
                this.state = state;
            }

            public override byte[] ToByteArray() => new byte[] { (byte)state };
        }
        public class RangeParser : ParserProp
        {
            public enum State : byte
            {
                integer = 0, hasDecimals = 1
            }
            public State state;
            public double Min;
            public double Max;

            public RangeParser(State state)
            {
                this.state = state;
            }

            public override byte[] ToByteArray()
            {
                var writer = new ArrayWriter(true);

                writer.Write((byte)state);

                if (state == State.integer)
                {
                    writer.Write((int)Min);
                    writer.Write((int)Max);
                }
                else
                {
                    writer.Write(Min);
                    writer.Write(Max);
                }

                return writer.ToArray();
            }
        }
    }
    public class ParserProp : ISerializable
    {
        public virtual byte[] ToByteArray()
        {
            return null;
        }
    }

    public Node()
    {
        Flags = FlagsEnum.root;
    }
    public Node(Node[] Childrens, FlagsEnum flags = FlagsEnum.root)
    {
        this.Flags = flags;
        if (Childrens == null) return;
        this.Childrens = Childrens.ToList();
    }
    public Node(Node[] Childrens, Node RedirectNode,
        FlagsEnum flags = FlagsEnum.HasRedirect) : this(Childrens, flags)
    {
        this.RedirectNode = RedirectNode;
    }
    public Node(Node[] Childrens, string SuggestionsTypeOrName,
        FlagsEnum flags = FlagsEnum.HasSuggestionsType) : this(Childrens, flags)
    {
        switch (flags)
        {
            case FlagsEnum.HasSuggestionsType:
                this.SuggestionsType = SuggestionsTypeOrName;
                break;
            case FlagsEnum.literal:
                this.Name = SuggestionsTypeOrName;
                break;
        }
            
    }
    public Node(Node[] Childrens, string Name,
        string Parser, ParserProp Properties,
        FlagsEnum flags = FlagsEnum.argument) : this(Childrens, Name, flags)
    {
        this.Parser = Parser;
        this.Properties = Properties;
    }
    public override string ToString()
    {
        if (Name != null)
            return $"<{Flags}, {Name}>";
        return $"<{Flags}>";
    }

    public byte[] ToByteArray()
    {
        var writer = new ArrayWriter(true);

        //header
        writer.Write((byte)Flags);
        writer.Write(Childrens.Select(x => new VarInt(x.index)).ToArray());

        if (Flags.HasFlag(FlagsEnum.HasRedirect))
            writer.Write(new VarInt(RedirectNode.index));
        if (Flags.HasFlag(FlagsEnum.literal) || Flags.HasFlag(FlagsEnum.argument))
            writer.Write(Name);
        if (Flags.HasFlag(FlagsEnum.argument))
        {
            if (Properties != null)
            {
                writer.Write(Parser);
                writer.Write(Properties);
            }
            else
                writer.Write(Parser);
        }
        if (Flags.HasFlag(FlagsEnum.HasSuggestionsType))
            writer.Write(SuggestionsType);

        return writer.ToArray();
    }
}
/*

/home (name:string)
/home add (name:string)
/home remove (name:string)
/home list

*/