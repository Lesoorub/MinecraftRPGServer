using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Item : ICloneable, ISerializable
{
    public bool Present { get => itemCount != 0; }
    public VarInt ItemID { get; set; }
    private byte itemCount = 0;
    public byte ItemCount 
    { 
        get => itemCount; 
        set => itemCount = Math.Min(Math.Max(value, (byte)0), (byte)64);
    }
    [JsonIgnore]
    public virtual bool sendNBT { get; } = false;
    [JsonIgnore]
    public NBTTag NBT 
    {
        get
        {
            var nbt = new NBTTag(new TAG_Compound(new List<TAG>(), "tag"));
            if (Damage != 0)
                nbt["Damage"] = new TAG_Int(Damage, "Damage");//OK

            var display = new List<TAG>();
            if (!string.IsNullOrEmpty(Name))
            {
                var c = Chat.ColoredText(Name);
                display.Add(new TAG_String(c.ToString(), "Name"));
            }
            if (!ChatName.Equals(default))
                display.Add(new TAG_String(ChatName.ToString(), "Name"));
            if (Lore != null && Lore.Length > 0)
            {
                display.Add(new TAG_List(
                    Lore.Select(x => (TAG)new TAG_String(Chat.ColoredText(x).ToString())).ToList(),
                    TAG_String._TypeID,
                    "Lore"));
            }
            if (display.Count > 0)
                nbt["display"] = new TAG_Compound(display, "display");

            return nbt;
        }
    } 
    [JsonIgnore]
    public virtual SlotType allowedType { get; } = SlotType.Any;

    [JsonIgnore]
    public string Name;
    [JsonIgnore]
    public Chat ChatName;
    [JsonIgnore]
    public string[] Lore;
    public int Damage;
    
    public static implicit operator Item(Slot slot) => FromSlot(slot);
    public static implicit operator Slot(Item item) => item != null ? new Slot(item.ItemID, item.ItemCount, item.sendNBT ? item.NBT : null) : default(Slot);

    public static Dictionary<string, int> NameIDs = new Dictionary<string, int>();
    public static Dictionary<int, Type> itemTypes = new Dictionary<int, Type>();

    public static void InitItems(byte[] ItemsRawData)
    {
        var timer = new Stopwatch();
        timer.Start();
        using (var ms = new MemoryStream(ItemsRawData))
        using (StreamReader streamReader = new StreamReader(ms))
        using (JsonTextReader reader = new JsonTextReader(streamReader))
        {
            var serializer = new JsonSerializer();
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    foreach (var prop in ((JObject)((JObject)serializer.Deserialize(reader))["entries"]).Properties())
                        NameIDs.Add(prop.Name, (int)prop.Value["protocol_id"]);
                }
            }
        }
        foreach (var item_type in RPGServer.GetTypesWithAttribute<ItemAttribute>())
        {
            var attr = item_type.GetCustomAttribute<ItemAttribute>();
            itemTypes.Add(NameIDs[attr.nameid], item_type);
        }
        timer.Stop();
        Console.WriteLine($"{NameIDs.Count} Items loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
    public static Item FromSlot(Slot slot)
    {
        if (slot.Present && itemTypes.TryGetValue(slot.ItemID, out var item_type))
        {
            var item = (Item)Activator.CreateInstance(item_type);
            item.ItemID = slot.ItemID;
            item.ItemCount = slot.ItemCount;
            return item;
        }
        return new Item()
        {
            ItemID = slot.ItemID,
            ItemCount = slot.ItemCount,
        };
    }
    public static Item Create(string nameid, byte count = 1)
    {
        if (count < 0 || count > 64) return null;
        if (!NameIDs.TryGetValue(nameid, out var id)) return null;
        if (itemTypes.TryGetValue(id, out var item_type))
        {
            var item = Activator.CreateInstance(item_type) as Item;
            item.ItemID = id;
            item.ItemCount = count;
            return item;
        }
        return new Item()
        {
            ItemID = id,
            ItemCount = count
        };
    }

    public object Clone()
    {
        return JsonConvert.DeserializeObject(
            JsonConvert.SerializeObject(this, PlayerData.jsonSerializerSettings), 
            PlayerData.jsonSerializerSettings);
    }

    public byte[] ToByteArray() => ((Slot)this).ToByteArray();
}
