using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inventory
{
    public class Item : ICloneable, ISerializable
    {
        [JsonIgnore]
        public bool Present { get => itemCount != 0; }
        public virtual ItemID ItemID { get; set; }
        private byte itemCount = 0;
        public byte ItemCount
        {
            get => itemCount;
            set => itemCount = Math.Min(Math.Max(value, (byte)0), DefaultMaxCount);
        }
        [JsonIgnore]
        public const byte DefaultMaxCount = 64;
        [JsonIgnore]
        public virtual byte MaxCount { get; } = DefaultMaxCount;
        [JsonIgnore]
        public virtual bool sendNBT { get; } = false;
        [JsonIgnore]
        public virtual CustomModelData model { get; }
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
                    var c = Chat.ColoredText("&r" + Name);
                    display.Add(new TAG_String(c.ToString(), "Name"));
                }
                if (!display.Any(x => x.name == "Name") && !ChatName.Equals(default))
                    display.Add(new TAG_String(ChatName.ToString(), "Name"));
                if (Lore != null && Lore.Length > 0)
                {
                    display.Add(new TAG_List(
                        Lore.Select(x => (TAG)new TAG_String(Chat.ColoredText("&r" + x).ToString())).ToList(),
                        TAG_String._TypeID,
                        "Lore"));
                }

                if (model != 0)
                    nbt["CustomModelData"] = new TAG_Int((int)model, "CustomModelData");

                if (display.Count > 0)
                    nbt["display"] = new TAG_Compound(display, "display");

                if (MaxCount == 1)
                    nbt["AntiStackNumber"] = new TAG_Long(RandomPlus.GetLong(), "AntiStackNumber");

                return nbt;
            }
        }
        
        [JsonIgnore]
        public virtual string Name { get; set; }
        [JsonIgnore]
        public Chat ChatName;
        [JsonIgnore]
        public virtual string[] Lore { get; set; }
        public int Damage;

        public virtual List<string> GetOreDict() => new List<string>() { GetNameID(ItemID) };

        public static implicit operator Item(Slot slot) => FromSlot(slot);
        public static implicit operator Slot(Item item) => item != null ? new Slot((int)item.ItemID, item.ItemCount, item.sendNBT ? item.NBT : null) : default(Slot);


        public static string[] ItemIDNames = Enum.GetNames(typeof(ItemID));
        public static string GetNameID(ItemID itemID) => ItemIDNames[(int)itemID];
        public static bool GetItemID(string nameID, out ItemID ItemID)
        {
            ItemID = ItemID.air;
            int id = Array.IndexOf(ItemIDNames, nameID);
            if (id == -1) 
                return false;
            ItemID = (ItemID)id;
            return true;
        }


        public static Dictionary<ItemID, Type> itemTypes = new Dictionary<ItemID, Type>();

        public static void InitItems()
        {
            var timer = new Stopwatch();
            timer.Start();
            foreach (var item_type in RPGServer.GetTypesWithAttribute<ItemAttribute>())
            {
                var attr = item_type.GetCustomAttribute<ItemAttribute>();
                itemTypes.Add(attr.itemID, item_type);
            }
            Items.RPGItem.Init();
            timer.Stop();
            Console.WriteLine($"{itemTypes.Count} Items loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
        }
        public static Item FromSlot(Slot slot)
        {
            ItemID itemID = (ItemID)(int)slot.ItemID;
            if (slot.Present && itemTypes.TryGetValue(itemID, out var item_type))
            {
                var item = (Item)Activator.CreateInstance(item_type);
                item.ItemID = itemID;
                item.ItemCount = slot.ItemCount;
                return item;
            }
            return new Item()
            {
                ItemID = itemID,
                ItemCount = slot.ItemCount,
            };
        }
        public static Item Create(ItemID itemID, byte count = 1)
        {
            if (count < 0) return null;
            if (itemTypes.TryGetValue(itemID, out var item_type))
            {
                var item = Activator.CreateInstance(item_type) as Item;
                item.ItemID = itemID;
                item.ItemCount = Math.Min(count, item.MaxCount);
                return item;
            }
            return new Item()
            {
                ItemID = itemID,
                ItemCount = Math.Min(count, DefaultMaxCount)
            };
        }

        public object Clone()
        {
            return JsonConvert.DeserializeObject(
                JsonConvert.SerializeObject(this, PlayerData.jsonSerializerSettings),
                PlayerData.jsonSerializerSettings);
        }

        public byte[] ToByteArray() => ((Slot)this).ToByteArray();

        public static bool ItemEquals(Item a, Item b) =>
            a != null && b != null &&
            a.ItemID == b.ItemID &&
            a.NBT.Bytes.SequenceEqual(b.NBT.Bytes);
        public static bool TryMove(ref Item target, ref Item from, byte count)
        {
            if (!ItemEquals(target, from) || count == 0) return false;
            if (from.ItemCount - count < 0) return false;
            int target_count = target.ItemCount;
            int from_count = from.ItemCount;

            target_count += count;
            from_count -= count;

            if (target_count > target.MaxCount)
            {
                from_count += target_count - target.MaxCount;
                target_count = target.MaxCount;
            }

            target.ItemCount = (byte)target_count;
            from.ItemCount = (byte)from_count;
            if (from.ItemCount == 0)
                from = null;
            return true;
        }
        public static void Swap(ref Item a, ref Item b)
        {
            var t = b;
            b = a;
            a = t;
        }
        public static bool CanPlace(IndexedItem to, Item item)
        {
            if (item == null) return false;
            var item_oreDict = item.GetOreDict();
            if (to.blacklistItems != null && to.blacklistItems.All(x => item_oreDict.Contains(x)))
                return false;
            if (to.allowedItems == null || to.allowedItems.Length == 0) 
                return true;
            if (to.allowedItems.All(x => item_oreDict.Contains(x))) 
                return true;
            return false;
        }
    }
}