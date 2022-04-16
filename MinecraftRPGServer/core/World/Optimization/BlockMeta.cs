using System.Collections.Generic;
using Newtonsoft.Json;
using MineServer;
using System;
using System.Text;

public struct BlockMeta
{
    public Dictionary<string, string[]> properties;
    public state[] states;
    public struct state
    {
        static Dictionary<int, Dictionary<string, string>> mapping = new Dictionary<int, Dictionary<string, string>>();
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

        public state(byte[] raw, ref int offset)
        {
            properties_pointer = BlocksMeta.GetInt(raw, ref offset);
            id = VarInt.Get(raw, ref offset);
            @default = raw[offset++] == 1;
        }
        static int Hash(Dictionary<string, string> t)
        {
            int hash = 1;
            foreach (var item in t)
                hash *= item.Key.GetHashCode() + (item.Value != null ? item.Value.GetHashCode() : 0);
            return hash;
        }

        public byte[] Bytes => BitConverter.GetBytes(properties_pointer).Combine(
            new VarInt(id),
            new byte[1]
            {
                    (byte)(@default.HasValue ? (@default.Value ? 1 : 0) : 2)
            });

        public static byte[] MappingBytes
        {
            get
            {
                byte[] Serialize(int key, Dictionary<string, string> value)
                {
                    byte[][] buffers2 = new byte[value.Count][];
                    int index = 0;
                    foreach (var pair in value)
                    {
                        var writer = new ArrayWriter();
                        writer.Write(pair.Key);
                        writer.Write(pair.Value);
                        buffers2[index++] = writer.ToArray();
                    }
                    return FastByteArrayExtensions.Combine(
                        BitConverter.GetBytes(key),
                        new VarInt(value.Count).Bytes,
                        FastByteArrayExtensions.Combine(objs: buffers2));
                }

                byte[][] buffers = new byte[mapping.Count][];
                int k = 0;
                foreach (var pair in mapping)
                    buffers[k++] = Serialize(pair.Key, pair.Value);

                return
                    FastByteArrayExtensions.Combine(
                        new VarInt(mapping.Count).Bytes,
                        FastByteArrayExtensions.Combine(objs: buffers));
            }
        }
        public static void LoadMapping(byte[] raw, ref int offset)
        {
            (int, Dictionary<string, string>) Deserialize(byte[] raw2, ref int offset2)
            {
                int key = BlocksMeta.GetInt(raw2, ref offset2);
                var value_Count = VarInt.Get(raw2, ref offset2);
                Dictionary<string, string> dict = new Dictionary<string, string>(value_Count);
                for (int k = 0; k < value_Count; k++)
                {
                    dict.Add(DecodeString(raw2, ref offset2), DecodeString(raw2, ref offset2));
                }
                return (key, dict);
            }

            var mapping_count = VarInt.Get(raw, ref offset);
            mapping = new Dictionary<int, Dictionary<string, string>>(mapping_count);
            for (int k = 0; k < mapping_count; k++)
            {
                var t = Deserialize(raw, ref offset);
                mapping.Add(t.Item1, t.Item2);
            }
        }
        public static string DecodeString(byte[] buffer, ref int offset, int maxN = -1)
        {
            var str_len = new VarInt(buffer, offset);
            if (maxN != -1 && str_len.value > maxN)
            {
                throw new Exception("Неверная строка, покарай ее");
            }
            if (buffer.Length <= offset || buffer.Length <= offset + str_len.length)
            {
                throw new Exception("Попытка чтения вне границ буффера");
            }
            string str = Encoding.UTF8.GetString(buffer, offset + str_len.length, str_len.value);
            offset += str_len.value + str_len.length;
            return str;
        }
    }

    public BlockMeta(byte[] raw, int offset)
    {
        var properties_Count = VarInt.Get(raw, ref offset);
        properties = new Dictionary<string, string[]>(properties_Count);
        for (int k = 0; k < properties_Count; k++)
        {
            string key = state.DecodeString(raw, ref offset);
            //string[] value = Get(raw, ref offset, VarInt.Get(raw, ref offset));
            var reader = new ArrayReader(raw, offset);
            string[] value = reader.Read<string[]>();
            offset = reader.offset;
            properties.Add(key, value);
        }
        var states_Length = VarInt.Get(raw, ref offset);
        states = new state[states_Length];
        for (int k = 0; k < states_Length; k++)
            states[k] = new state(raw, ref offset);
    }
    public byte[] Serialize(out int len)
    {
        //[propertiesLen:(VarInt)]
        //[properties:propertiesLen]
        //[statesLen:(VarInt)]
        //[states:statesLen]
        byte[] SerializePair(string key, string[] value)
        {
            //[key:keyLen][ArrayLen:(VarInt)][Array:ArrayLen]
            var writer = new ArrayWriter();
            writer.Write(key);
            writer.Write(value.Length);
            writer.Write(value);
            return writer.ToArray();
            //return new _string(key).Bytes.Combine(new VarInt(value.Length).Bytes, new ArrayOfString(value));
        }
        byte[] buffer = new byte[0];
        //properties
        buffer = buffer.Combine(new VarInt(properties != null ? properties.Count : 0).Bytes);
        if (properties != null)
        {
            foreach (var key in properties.Keys)
                buffer = buffer.Combine(SerializePair(key, properties[key]));
        }
        //states
        buffer = buffer.Combine(new VarInt(states != null ? states.Length : 0).Bytes);
        if (states != null)
        {
            for (int k = 0; k < states.Length; k++)
                buffer = buffer.Combine(states[k].Bytes);
        }
        len = buffer.Length;
        return buffer;
    }
}
