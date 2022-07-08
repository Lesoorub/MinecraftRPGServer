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
                        Y = (short)(ent["y"] as TAG_Int),
                        Type = type,
                        Data = (ent as TAG_Compound).RemoveTags(new string[] { "x", "y", "z", "id" })
                    };
                }
            }
        }

        var Sections = (nbt["sections"] as TAG_List).data;

        for (int k = 0; k < Sections.Count; k++)
        {
            var section = new ChunkSection();
            ChunkSectionParser.Parse(section, Sections[k]);
            obj.sections.Add(section.Y, section);
        }
        obj.isChanged = true;
    }
}
