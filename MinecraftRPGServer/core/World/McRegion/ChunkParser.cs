using System;
using System.Collections.Generic;
using System.Linq;
using NBT;

public static class ChunkParser
{
    public static void Parse(Chunk obj, NBTTag nbt)
    {
        obj.Heightmaps = nbt["Heightmaps"];
        obj.cPos = new v2i(nbt["xPos"] as TAG_Int, nbt["zPos"] as TAG_Int);
        TAG_List block_entities = nbt["block_entities"] as TAG_List;

        if (block_entities != null && block_entities.data.Count > 0)
        {
            obj.BlockEntities = new BlockEntity[block_entities.data.Count];

            int index = 0;
            foreach (var ent in block_entities.data)
            {
                if (BlockEntity.GetByNameID(ent["id"] as TAG_String, out var type))
                {
                    obj.BlockEntities[index++] = new BlockEntity()
                    {
                        blockX = (byte)(ent["x"] as TAG_Int & 0xF),
                        blockZ = (byte)(ent["z"] as TAG_Int & 0xF),
                        Y = (short)(int)ent["y"],
                        Type = new MineServer.VarInt((int)type),
                        Data = (ent as TAG_Compound).RemoveTags(new string[] { "x", "y", "z", "id" })
                    };
                }
            }
        }

        var Sections = (nbt["sections"] as TAG_List).data;

        for (int k = 0; k < Sections.Count; k++)
        {
            var section = new ChunkSection();
            section.X = obj.cPos.x;
            section.Z = obj.cPos.y;
            ChunkSectionParser.Parse(section, Sections[k]);
            obj.sections.Add(section.Y, section);
        }
        obj.isChanged = true;
    }
    public static NBTTag Serialize(Chunk obj)
    {
        NBTTag nbt = new NBTTag();
        nbt["Heightmaps"] = obj.Heightmaps;
        nbt["xPos"] = new TAG_Int(obj.cPos.x);
        nbt["zPos"] = new TAG_Int(obj.cPos.y);
        if (obj.BlockEntities != null)
        {
            nbt["block_entities"] = new TAG_List(obj.BlockEntities.Select(x =>
            {
                if (!BlockEntity.GetNameIDByType((BlockEntityID)x.Type.value, out var nameid)) return null;
                var t = new NBTTag(x.Data.ToByteArray());
                t["x"] = new TAG_Int(x.blockX);
                t["z"] = new TAG_Int(x.blockZ);
                t["y"] = new TAG_Int(x.Y);
                t["id"] = new TAG_String(nameid);
                return (TAG)t;
            }).Where(x => x != null).ToList(), TAG_Compound._TypeID);
        }
        nbt["sections"] = new TAG_List(
            obj.sections
                .Select(x => (TAG)ChunkSectionParser.Serialize(x.Value))
                .ToList(), 
            TAG_Compound._TypeID);
        return nbt;
    }
}
