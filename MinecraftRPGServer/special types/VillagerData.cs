using MineServer;
using NBT;

public struct VillagerData : ISerializable, IDeserializable
{
    public enum Type : byte
    {
        desert, jungle, plains, savanna, snow, swamp, taiga
    }
    public enum Profession : byte
    {
        none, armored, butcher, cartographer, cleric,
        farmer, fisherman, fletcher, leatherworker, librarian,
        mason, nitwit, shepherd, toolsmith, weaponsmith
    }

    public Type villagerType;
    public Profession villagerProfession;
    public byte Level;

    public VillagerData(Type type, Profession profession, byte level)
    {
        villagerType = type;
        villagerProfession = profession;
        Level = level;
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        var reader = new ArrayReader(bytes, offset, true);
        reader.Fill(this);
        length = reader.offset - offset;
    }

    public byte[] ToByteArray()
    {
        var writer = new ArrayWriter(true);
        writer.From(this);
        return writer.ToArray();
    }
}
