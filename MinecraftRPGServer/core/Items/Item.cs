using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Entities;
using Inventory.Items;
using MinecraftData._1_18_2.items.minecraft;
using NBT;
using Newtonsoft.Json;

namespace Inventory
{
    public class Item : ICloneable, ISerializable
    {
        [JsonIgnore]
        public bool Present { get => itemCount != 0; }
        public virtual ItemNameID ItemID { get; set; }
        private byte itemCount = 0;
        public byte ItemCount
        {
            get => itemCount;
            set => itemCount = Math.Min(Math.Max(value, (byte)0), DefaultMaxCount);
        }
        [JsonIgnore]
        public IBaseItem itemData => MinecraftData._1_18_2.items.minecraft.ItemAttribute.items[ItemID];
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
        public virtual bool OnTryingPlace(Player player, v3i Location, Direction Face, v3f cursor, out BlockState state)
        {
            var placeble = itemData as ICanPlaceBlock;
            state = default;
            if (placeble == null) return false;
            state = new BlockState(GlobalPalette.GetBlockData(placeble.block).DefaultStateID);
            return true;
        }

        public static implicit operator Item(Slot slot) => FromSlot(slot);
        public static implicit operator Slot(Item item) => item != null ? new Slot((int)item.ItemID, item.ItemCount, item.sendNBT ? item.NBT : null) : default(Slot);


        public static string[] ItemIDNames = Enum.GetNames(typeof(ItemNameID));
        public static string GetNameID(ItemNameID itemID) => ItemIDNames[(int)itemID];
        public static bool GetItemID(string nameID, out ItemNameID ItemID)
        {
            ItemID = ItemNameID.air;
            int id = Array.IndexOf(ItemIDNames, nameID);
            if (id == -1)
                return false;
            ItemID = (ItemNameID)id;
            return true;
        }


        public static Dictionary<ItemNameID, Type> itemTypes = new Dictionary<ItemNameID, Type>();

        public static void InitItems()
        {
            foreach (var item_type in Tools.GetAllTypesWithAttribute<ItemAttribute>())
            {
                var attr = item_type.GetCustomAttribute<ItemAttribute>();
                itemTypes.Add(attr.itemID, item_type);
            }
            Items.RPGItem.Init();
        }
        public static Item FromSlot(Slot slot)
        {
            ItemNameID itemID = (ItemNameID)(int)slot.ItemID;
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
        public static Item Create(ItemNameID itemID, byte count = 1)
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

        public static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            CheckAdditionalContent = true,
        };
        public object Clone()
        {
            return JsonConvert.DeserializeObject(
                JsonConvert.SerializeObject(this, jsonSerializerSettings),
                jsonSerializerSettings);
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