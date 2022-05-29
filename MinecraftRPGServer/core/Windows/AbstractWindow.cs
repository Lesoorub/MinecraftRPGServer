using System;
using System.Collections.Generic;
using System.Linq;
using Packets.Play;
using static Inventory.Item;

namespace Inventory
{
    public abstract class AbstractWindow
    {
        public byte WindowID;
        public virtual Chat WindowTitle { get; set; } = Chat.ColoredText("Window");
        public virtual Slot[] Slots => Combine(inventory, pinv.mainInv, pinv.hotbar);
        public IndexedItem[] inventory { get; set; }
        public virtual int Type { get; }
        protected InventoryOfPlayer pinv;
        public ItemMovement movement = new ItemMovement();
        public virtual int hotbarIndex => inventory.Length + 27;
        public virtual int mainInvIndex => inventory.Length;


        public AbstractWindow(InventoryOfPlayer player)
        {
            this.pinv = player;
        }
        public virtual Item GetItem(int index) => null;
        public virtual IndexedItem GetSlot(int index) => default;
        public virtual void SetSlot(int index, Item newItem) { }
        /// <summary>
        /// Processing packet
        /// </summary>
        /// <param name="packet"></param>
        /// <returns>true if successfuly overwise false</returns>
        public virtual bool ClickWindow(Player player, ClickWindow packet)
        {
            var mode = packet.Mode;
            var button = packet.Button;
            var slot = packet.Slot;
            bool Invoke(ItemMovement.AbstractClick abs)
            {
                var item = GetItem(slot);
                abs.slot = slot;
                abs.button = button;
                abs.CarriedItem = pinv.CarriedItem.item;
                abs.window = this;
                abs.player = player;     
                var result = abs.ClickOnSlot(ref item);
                pinv.CarriedItem.item = abs.CarriedItem;
                if (pinv.CarriedItem.item != null && pinv.CarriedItem.item.ItemCount == 0)
                    pinv.CarriedItem.item = null;
                SetSlot(slot, item);
                return result;
            }
            //Console.WriteLine($"mode={mode}, button={button}, slot={slot}, GetItem(slot)={(Slot)GetItem(slot)}, CI={(Slot)pinv.CarriedItem.item}");
            if (GetSlot(slot).readOnly) 
                return false;
            if (slot != -1)
            {
                switch (mode)
                {
                    case 0://Mouse click
                        if (button == 0)//Left
                        {
                            if (slot == -999)
                            {
                                //Drop CI
                                if (pinv.CarriedItem.item != null)
                                    player.DropItem(ref pinv.CarriedItem.item, pinv.CarriedItem.item.ItemCount);
                                return true;
                            }
                            return Invoke(movement.leftClick);
                        }
                        else if (button == 1)//Right
                        {
                            if (slot == -999)
                            {
                                //Drop stack item from CI
                                if (pinv.CarriedItem.item != null && pinv.CarriedItem.item.ItemCount >= 1)
                                    player.DropItem(ref pinv.CarriedItem.item, 1);
                                return true;
                            }
                            return Invoke(movement.rightClick);
                        }
                        break;
                    case 1://Shift + left mouse click
                        return Invoke(movement.shiftClick);
                    case 2://Number key {BUTTON}
                           //if Button == 40 it is Offhand swap key F
                        {
                            int newindex = hotbarIndex + button;
                            if (button == 40)
                                newindex = hotbarIndex + 9;
                            if (slot != newindex)
                            {
                                var hotbarSlot = GetSlot(newindex);
                                var itemSlot = GetSlot(slot);

                                if (hotbarSlot.readOnly || itemSlot.readOnly)
                                    return false;
                            }
                            return Invoke(movement.numKeyClick);
                        }
                    case 3://Middle click, only creative in non-player inventory
                        if (player.Gamemode != GamemodeType.Creative) break;
                        {
                            var item = GetItem(slot);
                            if (item == null) break;
                            pinv.CarriedItem.item = (Item)item.Clone();
                            pinv.CarriedItem.item.ItemCount = pinv.CarriedItem.item.MaxCount;
                        }
                        return true;
                    case 4://Drop
                           //Clicked item is always empty
                        {
                            var item = GetItem(slot);
                            if (item == null) break;
                            if (button == 0)//Q
                                player.DropItem(slot, 1);
                            else if (button == 1)//Control + Q
                                player.DropItem(slot, item.ItemCount);
                        }
                        break;
                    case 5://Painting (PAIN)
                        return Invoke(movement.painting);
                    case 6://Double click
                        {
                            if (button == 0)
                                return Invoke(movement.doubleClick);
                        }
                        return false;
                    default:
                        break;
                }
            }
            return true;
        }
        public virtual void Open(Player player)
        {
            WindowID = player.LastWindowID++;
            player.SecondWindow = this;
            player.network.Send(new OpenWindow()
            {
                WindowID = WindowID,
                WindowType = Type,
                WindowTitle = WindowTitle,
            });
            SendItems(player);
        }
        public virtual void SendItems(Player player)
        {
            player.network.Send(new WindowItems()
            {
                WindowID = WindowID,
                StateID = player.LastStateID++,
                slots = Slots,
                CarriedItem = player.inventory.CarriedItem.item
            });
        }
        protected Slot[] Combine(params object[] items)
        {
            return items
                .Select(x => x is IndexedItem[] arr ? arr : new IndexedItem[] { (IndexedItem)x })
                .SelectMany(x => x)
                .Select(x => (Slot)x.item)
                .ToArray();
        }
        public sealed class ItemMovement
        {
            public LeftClick leftClick = new LeftClick();
            public RightClick rightClick = new RightClick();
            public DoubleClick doubleClick = new DoubleClick();
            public NumKeyClick numKeyClick = new NumKeyClick();
            public ShiftClick shiftClick = new ShiftClick();
            public PaintingClick painting = new PaintingClick();
            public abstract class AbstractClick
            {
                public int slot;
                public int button;
                public Item CarriedItem;
                public AbstractWindow window;
                public Player player;
                public virtual bool ClickOnSlot(ref Item item) => default;
            }
            public sealed class LeftClick : AbstractClick
            {
                public override bool ClickOnSlot(ref Item item)
                {
                    if (item == null && CarriedItem == null) return false;
                    if (item == null || CarriedItem == null)//Drop from CI
                    {
                        if (item == null && CarriedItem != null)//CI != null && item == null
                        {
                            if (CanPlace(window.GetSlot(slot), CarriedItem))
                            {
                                Swap(ref item, ref CarriedItem);
                                return true; 
                            }
                        }
                        else//CI == null && item != null
                        {
                            Swap(ref item, ref CarriedItem);
                            return true;
                        }
                    }
                    else if (ItemEquals(item, CarriedItem))//Try Add To item from CI
                    {
                        TryMove(ref item, ref CarriedItem, CarriedItem.ItemCount);
                        return true;
                    }
                    else
                    {
                        Swap(ref item, ref CarriedItem);
                        return true;
                    }
                    return false;
                }
            }
            public sealed class RightClick : AbstractClick
            {
                public override bool ClickOnSlot(ref Item item)
                {
                    if (item == null && CarriedItem == null) return false;
                    if (item == null)
                    {
                        //set item with count equal 1 from CI
                        if (CanPlace(window.GetSlot(slot), CarriedItem))
                        {
                            item = (Item)CarriedItem.Clone();
                            item.ItemCount = 0;
                            TryMove(ref item, ref CarriedItem, 1);
                            return true;
                        }
                    }
                    else
                    {
                        if (CarriedItem == null)
                        {
                            //grab clicked item with item.count / 2 count.
                            CarriedItem = (Item)item.Clone();
                            CarriedItem.ItemCount = 0;
                            TryMove(ref CarriedItem, ref item, (byte)Math.Ceiling(item.ItemCount / 2f));
                            return true;
                        }
                        else
                        {
                            if (ItemEquals(item, CarriedItem))
                            {
                                //add 1
                                TryMove(ref item, ref CarriedItem, 1);
                                return true;
                            }
                            else
                            {
                                //Swap
                                if (CanPlace(window.GetSlot(slot), CarriedItem))
                                {
                                    Swap(ref item, ref CarriedItem);
                                    return true;
                                }
                            }
                        }
                    }
                    return false;
                }
            }
            public sealed class DoubleClick : AbstractClick
            {
                public override bool ClickOnSlot(ref Item item)
                {
                    if (CarriedItem == null) return false;
                    bool ret = false;
                    for (int k = window.mainInvIndex; k < window.mainInvIndex + 36; k++)
                    {
                        if (k == slot)
                            continue;
                        var k_slot = window.GetSlot(k);
                        if (k_slot.readOnly) continue;
                        var k_item = k_slot.item;
                        if (!ItemEquals(k_item, CarriedItem))
                            continue;
                        if (k_item.ItemCount == k_item.MaxCount) continue;
                        if (TryMove(ref CarriedItem, ref k_item, k_item.ItemCount))
                        {
                            window.SetSlot(k, k_item);
                            if (CarriedItem.ItemCount == CarriedItem.MaxCount)
                                return true;
                        }
                        ret = true;
                    }
                    for (int k = window.mainInvIndex; k < window.mainInvIndex + 36; k++)
                    {
                        if (k == slot)
                            continue;
                        var k_slot = window.GetSlot(k);
                        if (k_slot.readOnly) continue;
                        var k_item = k_slot.item;
                        if (!ItemEquals(k_item, CarriedItem))
                            continue;
                        if (TryMove(ref CarriedItem, ref k_item, k_item.ItemCount))
                        {
                            window.SetSlot(k, k_item);
                            if (CarriedItem.ItemCount == CarriedItem.MaxCount)
                                return true;
                        }
                        ret = true;
                    }
                    return ret;
                }
            }
            public sealed class NumKeyClick : AbstractClick
            {
                public override bool ClickOnSlot(ref Item item)
                {
                    int newindex = window.hotbarIndex + button;
                    if (button == 40)
                        newindex = window.hotbarIndex + 9;
                    if (slot != newindex)
                    {
                        var hotbarSlot = window.GetSlot(newindex);
                        var itemSlot = window.GetSlot(slot);

                        if (hotbarSlot.readOnly || itemSlot.readOnly)
                            return false;
                        if (itemSlot.item == null && hotbarSlot.item == null)
                            return false;
                        if (itemSlot.item != null && !CanPlace(hotbarSlot, itemSlot.item))
                            return false;
                        if (hotbarSlot.item != null && !CanPlace(itemSlot, hotbarSlot.item))
                            return false;
                        var t = window.GetItem(newindex);
                        Swap(ref item, ref t);
                        window.SetSlot(newindex, t);
                        return true;
                    }
                    return false;
                }
            }
            public sealed class ShiftClick : AbstractClick
            {
                bool isMainInv => slot >= window.mainInvIndex && slot < window.mainInvIndex + 27;
                bool isHotbar => slot >= window.hotbarIndex && slot < window.hotbarIndex + 9;
                bool isInventory => slot >= 0 && slot < window.inventory.Length;
                public override bool ClickOnSlot(ref Item item)
                {
                    if (window.GetSlot(slot).readOnly) 
                        return false;
                    if (window.Type == -1)
                    {
                        if (isMainInv)
                        {
                            if (!Move(5, 8, ref item))//Armor
                                return Move(window.hotbarIndex, window.hotbarIndex + 8, ref item);//Hotbar
                        }
                        else if (isHotbar)
                        {
                            if (!Move(5, 8, ref item))//Armor
                                return Move(window.mainInvIndex, window.mainInvIndex + 26, ref item);//MainInv
                        }
                        else//Armor
                        {
                            if (!Move(window.mainInvIndex, window.mainInvIndex + 26, ref item))//MainInv
                                return Move(window.hotbarIndex, window.hotbarIndex + 8, ref item);//Hotbar
                        }
                    }
                    else
                    {
                        if (isInventory)
                        {
                            if (!Move(window.hotbarIndex, window.hotbarIndex + 8, ref item))//Hotbar
                                return Move(window.mainInvIndex, window.mainInvIndex + 26, ref item);//MainInv
                        }
                        else if (isMainInv)
                        {
                            if (!Move(0, window.inventory.Length - 1, ref item))//Inventory
                                return Move(window.hotbarIndex, window.hotbarIndex + 8, ref item);//Hotbar
                        }
                        else//Hotbar
                        {
                            if (!Move(0, window.inventory.Length - 1, ref item))//Inventory
                                return Move(window.mainInvIndex, window.mainInvIndex + 26, ref item);//MainInv
                        }
                    }
                    return false;
                }
                bool Move(int start, int end, ref Item item)
                {
                    if (item == null) return false;
                    //Попытка добавить в существующие стаки
                    for (int k = start; k <= end; k++)
                    {
                        var k_slot = window.GetSlot(k);
                        if (k_slot.readOnly) continue;
                        var k_item = k_slot.item;
                        if (k_item != null)
                            TryMove(ref k_item, ref item, item.ItemCount);
                        window.SetSlot(k, k_item);
                        if (item == null) return true;
                    }
                    //Попытка положить в пустой слот
                    for (int k = start; k <= end; k++)
                    {
                        var k_slot = window.GetSlot(k);
                        if (k_slot.readOnly) continue;
                        var k_item = k_slot.item;
                        if (k_item == null && CanPlace(k_slot, window.GetSlot(slot).item))
                        {
                            k_item = (Item)item.Clone();
                            k_item.ItemCount = 0;
                            TryMove(ref k_item, ref item, item.ItemCount);
                            window.SetSlot(k, k_item);
                            if (item == null) return true;
                        }
                    }
                    return false;
                }
            }
            public sealed class PaintingClick : AbstractClick
            {
                enum Type : byte
                {
                    none,
                    equal,
                    ones,
                    creative
                }
                Type type = Type.none;
                List<int> slots = new List<int>();
                public override bool ClickOnSlot(ref Item item)
                {
                    if (slot == -999)//Starting/Ending mouse drag
                    {
                        switch (button)
                        {
                            //starting
                            case 0://left
                                if (CarriedItem != null)
                                    type = Type.equal;
                                return true;
                            case 4://right
                                if (CarriedItem != null)
                                    type = Type.ones;
                                return true;
                            case 8://middle
                                if (CarriedItem != null && player.Gamemode == GamemodeType.Creative)
                                    type = Type.creative;
                                return true;
                            //ending
                            case 2://left
                                if (CarriedItem != null)
                                {
                                    byte count = (byte)(CarriedItem.ItemCount / slots.Count);
                                    foreach (var k in slots)
                                    {
                                        var k_slot = window.GetSlot(k);
                                        if (k_slot.readOnly) continue;
                                        if (k_slot.item == null)
                                        {
                                            k_slot.item = (Item)CarriedItem.Clone();
                                            k_slot.item.ItemCount = 0;
                                            TryMove(ref k_slot.item, ref CarriedItem, count);
                                            window.SetSlot(k, k_slot.item);
                                        }
                                        else TryMove(ref k_slot.item, ref CarriedItem, count);
                                    }
                                }
                                type = Type.none;
                                slots.Clear();
                                return true;
                            case 6://right
                                foreach (var k in slots)
                                {
                                    byte count = 1;
                                    var k_slot = window.GetSlot(k);
                                    if (k_slot.readOnly) continue;
                                    if (k_slot.item == null)
                                    {
                                        k_slot.item = (Item)CarriedItem.Clone();
                                        k_slot.item.ItemCount = 0;
                                        TryMove(ref k_slot.item, ref CarriedItem, count);
                                        window.SetSlot(k, k_slot.item);
                                    }
                                    else
                                        TryMove(ref k_slot.item, ref CarriedItem, count);
                                }
                                type = Type.none;
                                slots.Clear();
                                return true;
                            case 10://middle
                                if (player.Gamemode == GamemodeType.Creative)
                                {
                                    CarriedItem.ItemCount = CarriedItem.MaxCount;
                                    foreach (var k in slots)
                                    {
                                        var k_slot = window.GetSlot(k);
                                        if (k_slot.readOnly) continue;
                                        if (k_slot.item == null)
                                        {
                                            k_slot.item = (Item)CarriedItem.Clone();
                                            window.SetSlot(k, k_slot.item);
                                        }
                                        else if (ItemEquals(CarriedItem, k_slot.item))
                                        {
                                            k_slot.item = (Item)CarriedItem.Clone();
                                            window.SetSlot(k, k_slot.item);
                                        }
                                    }
                                }
                                type = Type.none;
                                slots.Clear();
                                return true;
                        }
                        return false;
                    }
                    if (type == Type.none)
                    {
                        slots.Clear();
                        return false;
                    }
                    //in the future, the slot is considered normal
                    if (slots.Contains(slot)) return false;
                    slots.Add(slot);
                    switch (type)
                    {
                        case Type.creative:
                            CarriedItem.ItemCount = CarriedItem.MaxCount;
                            foreach (var k in slots)
                            {
                                var s = window.GetSlot(k);
                                if (s.readOnly) continue;
                                s.item = (Item)CarriedItem.Clone();
                                window.SetSlot(k, s.item);
                            }
                            return true;
                    }
                    return false;
                }
            }
        }
    }
}