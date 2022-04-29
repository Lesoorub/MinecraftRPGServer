using System.Collections.Generic;
using Newtonsoft.Json;
using MineServer;
using System;
using System.Text;

public struct BlockMeta : ISerializable, IDeserializable
{
    public Dictionary<string, string[]> properties;
    public state[] states;
    public struct state : ISerializable, IDeserializable
    {
        public static Dictionary<int, Dictionary<string, string>> mapping = new Dictionary<int, Dictionary<string, string>>();
        [JsonIgnore]
        public int properties_pointer;
        public Dictionary<string, string> properties
        {
            get =>
                properties_pointer != 0 && mapping.ContainsKey(properties_pointer)
                ? mapping[properties_pointer] : default;
            set
            {
                int hash = Hash(value);
                properties_pointer = hash;
                if (!mapping.ContainsKey(hash))
                    mapping.Add(hash, value);
            }
        }
        public int id;
        public bool? @default;

        static int Hash(Dictionary<string, string> t)
        {
            int hash = 1;
            foreach (var item in t)
                hash *= item.Key.GetHashCode() + (item.Value != null ? item.Value.GetHashCode() : 0);
            return hash;
        }

        public void FromByteArray(byte[] bytes, int offset, out int length)
        {
            var reader = new ArrayReader(bytes, offset);
            id = reader.Read<int>();
            if (reader.Read<bool>())
                @default = reader.Read<bool>();
            else
                @default = null;
            properties = reader.Read<Dictionary<string, string>>();
            length = reader.offset - offset;
        }

        public byte[] ToByteArray()
        {
            var writer = new ArrayWriter();
            writer.Write(id);
            writer.Write(@default.HasValue);
            if (@default.HasValue)
                writer.Write(@default.Value);
            writer.Write(properties);
            return writer.ToArray();
        }
    }

    public byte[] ToByteArray()
    {
        var writer = new ArrayWriter();
        writer.From(this);
        return writer.ToArray();
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        var reader = new ArrayReader(bytes, offset);
        var t = (BlockMeta)reader.Fill(this);
        properties = t.properties;
        states = t.states;
        length = reader.offset - offset;
    }
}
