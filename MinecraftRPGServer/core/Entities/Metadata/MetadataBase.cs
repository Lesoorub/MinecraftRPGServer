using MineServer;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

public class MetadataBase
{
    public static Dictionary<Type, int> Types = new Dictionary<Type, int>()
    {
        { typeof(byte), 0 },
        { typeof(VarInt), 1 },
        { typeof(float), 2 },
        { typeof(string), 3 },
        { typeof(Chat), 4 },
        { typeof(Chat?), 5 },
        { typeof(Slot), 6 },
        { typeof(Inventory.Item), 6 },
        { typeof(bool), 7 },
        { typeof(v3f), 8 },
        { typeof(Position), 9 },
        { typeof(Position?), 10 },
        { typeof(Direction), 11 },
        { typeof(Guid?), 12 },
        { typeof(OptBlockID), 13 },
        { typeof(NBTTag), 14 },
        { typeof(Particle), 15 },
        { typeof(VillagerData), 16 },
        { typeof(VarInt?), 17 },
        { typeof(Pose), 18 },
    };

    Dictionary<int, ProtectedField> Fields = new Dictionary<int, ProtectedField>();
    Dictionary<int, long> changes = new Dictionary<int, long>();

    public object this[string nameindex]
    {
        get => GetFieldByName(nameindex, out var _).value;
        set
        {
            var field = GetFieldByName(nameindex, out var index);
            field.value = value;
            changes[index] = Time.GetTime();
        }
    }

    public void InitFields()
    {
        var type = GetType();
        foreach (var field in type.GetFields())
        {
            var indexAttr = field.GetCustomAttribute<IndexAttribute>();
            if (indexAttr == null) continue;
            Fields.Add(indexAttr.index, new ProtectedField()
            {
                name = field.Name,
                Type = GetMetadataType(field.FieldType),
                value = field.GetValue(this),
                fieldType = field.FieldType
            });
        }
    }
    public byte[] GetMetadataChanges(long mintime)
    {
        var writer = new ArrayWriter(true);

        foreach (var pair in changes.Where(x => x.Value > mintime))
            WriteField(writer, pair.Key);

        writer.Write((byte)0xFF);
        return writer.ToArray();
    }
    public byte[] GetAllMetadata()
    {
        var writer = new ArrayWriter(true);

        foreach (var pair in Fields)
            WriteField(writer, pair.Key);

        writer.Write((byte)0xFF);
        return writer.ToArray();
    }

    public void SetFlag(string nameindex, byte value)
    {
        var v = this[nameindex];
        this[nameindex] = Enum.ToObject(v.GetType(), (byte)((byte)Convert.ChangeType(v, typeof(byte)) | value));
    }
    public void SetFlag(string nameindex, int value)
    {
        var v = this[nameindex];
        this[nameindex] = Enum.ToObject(v.GetType(), (int)Convert.ChangeType(v, typeof(int)) | value);
    }
    public void RemoveFlag(string nameindex, byte value)
    {
        var v = this[nameindex];
        this[nameindex] = Enum.ToObject(v.GetType(), (byte)((byte)Convert.ChangeType(this[nameindex], typeof(byte)) & ~value));
    }
    public void RemoveFlag(string nameindex, int value)
    {
        var v = this[nameindex];
        this[nameindex] = Enum.ToObject(v.GetType(), (int)Convert.ChangeType(this[nameindex], typeof(int)) & ~value);
    }

    void WriteField(ArrayWriter writer, int index)
    {
        var field = Fields[index];
        writer.Write((byte)index);//index
        writer.Write(field.Type);//type
        writer.Write(field.value, field.fieldType);//value
    }

    public static VarInt GetMetadataType(Type field_type)
    {
        if (Types.TryGetValue(field_type, out var Type))
            return new VarInt(Type);//Type
        else if (field_type.BaseType == typeof(Enum) &&
                 Types.TryGetValue(Enum.GetUnderlyingType(field_type), out Type))
            return new VarInt(Type);//Type
        else
            throw new Exception("Not supported metadata type: " + field_type);
    }

    ProtectedField GetFieldByName(string nameindex, out int index)
    {
        var f = Fields.Where(x => x.Value.name.Equals(nameindex));
        if (f.Count() > 0)
        {
            var pair = f.ElementAt(0);
            index = pair.Key;
            return pair.Value;
        }
        throw new Exception("Field not found");
    }

    class ProtectedField
    {
        public string name;
        public object value;
        public VarInt Type;
        public Type fieldType;
    }
}