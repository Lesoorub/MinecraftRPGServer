using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using MineServer;


public partial class BlocksMeta
{
    public const string path = "chahe";
    public const string MapPath = path + "/blocks.json._map";
    public const string ChahePath = path + "/blocks.json.chahe";
    public byte[] data;
    public Dictionary<int, int> hashkeys = new Dictionary<int, int>();
    public Dictionary<short, int> stateIds = new Dictionary<short, int>();
    public Dictionary<int, BlockMeta> blocks;
    public BlocksMeta(byte[] blocks)
    {
        new DirectoryInfo(path).Create();
        if (!File.Exists(ChahePath) || !File.Exists(MapPath))
            GenerateChahe(blocks);
        //map:
        //[sourceHash:sourcehashLen]
        //[(n = data.Count):4]
        //[(m = stateIDs):4]
        //[HashKeyOffsets:(8*n)]
        //[stateIDOffsets:(6*stateIDs)]
        byte[] map = File.ReadAllBytes(MapPath);
        data = File.ReadAllBytes(ChahePath);
        int offset = 0;
        int Count = VarInt.Get(map, ref offset);
        var m = VarInt.Get(map, ref offset);
        for (int k = 0; k < Count; k++)
            hashkeys.Add(GetInt(map, ref offset), VarInt.Get(map, ref offset));
        for (int k = 0; k < m; k++)
            stateIds.Add((short)VarInt.Get(map, ref offset), VarInt.Get(map, ref offset));
        BlockMeta.state.LoadMapping(map, ref offset);
        this.blocks = new Dictionary<int, BlockMeta>(16);
    }
    public static int GetInt(byte[] buffer, ref int offset)
    {
        var t = BitConverter.ToInt32(buffer, offset);
        offset += 4;
        return t;
    }
    public BlockMeta Get(string id)
    {
        var offset = hashkeys[BitConverter.ToInt32(id.GetSha1().Take(4), 0)];
        if (!blocks.ContainsKey(offset))
            blocks.Add(offset, new BlockMeta(data, offset));
        return blocks[offset];
    }
    public BlockMeta Get(short stateID)
    {
        var offset = stateIds[stateID];
        if (!blocks.ContainsKey(offset))
            blocks.Add(offset, new BlockMeta(data, offset));
        return blocks[offset];
    }
    private void GenerateChahe(byte[] blocks)
    {
        using (var ms = new MemoryStream(blocks))
        using (var streamReader = new StreamReader(ms))
        using (var reader = new JsonTextReader(streamReader))
        {
            var serializer = new JsonSerializer();
            var dat = Serialize(serializer.Deserialize<Dictionary<string, BlockMeta>>(reader));
            File.WriteAllBytes(MapPath, dat.map);
            File.WriteAllBytes(ChahePath, dat.data);
        }
    }
    private (byte[] map, byte[] data) Serialize(Dictionary<string, BlockMeta> data)
    {
        int stateIDs = 0;
        foreach (var pair in data)
            foreach (var state in pair.Value.states)
                stateIDs++;

        byte[][] HashKeyOffsets = new byte[data.Count][];//[stringhash:4][fileoffset:(VarInt)]
        byte[][] stateIDOffsets = new byte[stateIDs][];//[stateId:(VarInt)][fileoffset:(VarInt)]
        byte[][] dataBuffer = new byte[data.Count][];
        //map:
        //[(n = data.Count):4]
        //[(m = stateIDs):4]
        //[HashKeyOffsets:(8*n)]
        //[stateIDOffsets:(6*stateIDs)]
        //[BlockMeta::state::mapping.Count:(VarInt)]
        //[BlockMeta::state::mapping]
        //data:
        //[data]
        int k = 0;
        int i = 0;
        int offset = 0;
        foreach (var pair in data)
        {
            var _offset = new VarInt(offset);
            foreach (var state in pair.Value.states)
                stateIDOffsets[i++] = new VarInt(state.id).Bytes.Combine(_offset.Bytes);
            HashKeyOffsets[k] = pair.Key.GetSha1().Take(4).Combine(_offset.Bytes);
            dataBuffer[k] = pair.Value.Serialize(out var len);
            offset += len;
            k++;
        }

        return
            (FastByteArrayExtensions.Combine(
            new VarInt(data.Count).Bytes,
            new VarInt(stateIDOffsets.Length).Bytes,
            FastByteArrayExtensions.Combine(objs: HashKeyOffsets),
            FastByteArrayExtensions.Combine(objs: stateIDOffsets),
            BlockMeta.state.MappingBytes),
            FastByteArrayExtensions.Combine(objs: dataBuffer));
    }
}
