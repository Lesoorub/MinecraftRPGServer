using System;
using System.Collections.Generic;
using System.Linq;
using Packets.Play;

public abstract class AbstractWindow
{
    public virtual Slot[] Slots => Combine(inventory, pinv.mainInv, pinv.hotbar);
    public IndexedItem[] inventory { get; set; }
    public virtual int Type { get; }
    public virtual string Name { get; }
    protected InventoryOfPlayer pinv;
    public void OnItemChanged_Invoke(Item item, int index) => OnItemChanged?.Invoke(item, index);
    public delegate void ItemChangedArgs(Item item, int index);
    public event ItemChangedArgs OnItemChanged;
    public AbstractWindow(InventoryOfPlayer player)
    {
        this.pinv = player;
    }
    public ItemMovement movement = new ItemMovement();
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
        void Invoke(ItemMovement.AbstractClick abs)
        {
            var item = GetItem(slot);
            abs.index = slot;
            abs.button = button;
            abs.CarriedItem = pinv.CarriedItem.item;
            abs.window = this;
            abs.player = player;
            abs.ClickOnSlot(ref item);
            pinv.CarriedItem.item = abs.CarriedItem;
            if (pinv.CarriedItem.item != null && pinv.CarriedItem.item.ItemCount == 0)
                pinv.CarriedItem.item = null;
            SetSlot(slot, item);
        }
        Console.WriteLine($"mode={mode}, button={button}, slot={slot}, GetItem(slot)={(Slot)GetItem(slot)}, CI={(Slot)pinv.CarriedItem.item}");
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
                        Invoke(movement.leftClick);
                        break;
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
                        Invoke(movement.rightClick);
                        break;
                    }
                    break;
                case 1://Shift + left mouse click
                    Invoke(movement.shiftClick);
                    break;
                case 2://Number key {BUTTON}
                       //if Button == 40 it is Offhand swap key F
                    Invoke(movement.numKeyClick);
                    break;
                case 3://Middle click, only creative in non-player inventory
                    if (player.Gamemode != GamemodeType.Creative) break;
                    {
                        var item = GetItem(slot);
                        if (item == null) break;
                        pinv.CarriedItem.item = (Item)item.Clone();
                        pinv.CarriedItem.item.ItemCount = 64;
                    }
                    break;
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
                    Invoke(movement.painting);
                    break;
                case 6://Double click
                    if (button == 0)
                        Invoke(movement.doubleClick);
                    break;
                default:
                    return false;
            }
        }

        foreach(var sl in packet.Slots)
            OnItemChanged?.Invoke(GetItem(sl.index), sl.index);

        return true;
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
            public int index;
            public int button;
            public SlotType slotType;
            public Item CarriedItem;
            public AbstractWindow window;
            public Player player;
            public virtual void ClickOnSlot(ref Item item) { }
            protected bool ItemEquals(Item a, Item b) =>
                a != null && b != null &&
                a.ItemID.value == b.ItemID.value &&
                a.NBT.Bytes.SequenceEqual(b.NBT.Bytes);
            protected bool TryMove(ref Item target, ref Item from, byte count)
            {
                if (!ItemEquals(target, from) || count == 0) return false;
                if (from.ItemCount - count < 0) return false;
                target.ItemCount += count;
                from.ItemCount -= count;
                if (target.ItemCount > 64)
                {
                    from.ItemCount = (byte)(target.ItemCount - 64);
                    target.ItemCount = 64;
                }
                if (from.ItemCount == 0)
                    from = null;
                return true;
            }
            protected void Swap(ref Item a, ref Item b)
            {
                var t = b;
                b = a;
                a = t;
            }
            protected bool CanPlace(IndexedItem to, IndexedItem item)
            {
                if (to.type == SlotType.Any) return true;
                if (to.type == SlotType.ReadOnly) return false;
                if (to.type == SlotType.CustomList && 
                    to.allowedIDs.Contains(item.item.ItemID)) 
                    return true;
                if (  to.type.HasFlag(SlotType.Armor) && 
                    item.type.HasFlag(SlotType.Armor))
                {
                    if (  to.type.HasFlag(SlotType.Helmet) && 
                        item.type.HasFlag(SlotType.Helmet)) return true;
                    if (  to.type.HasFlag(SlotType.Chestplate) && 
                        item.type.HasFlag(SlotType.Chestplate)) return true;
                    if (  to.type.HasFlag(SlotType.Leggins) && 
                        item.type.HasFlag(SlotType.Leggins)) return true;
                    if (  to.type.HasFlag(SlotType.Boots) && 
                        item.type.HasFlag(SlotType.Boots)) return true;
                }
                return false;
            }
        }
        public sealed class LeftClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                if (item == null && CarriedItem == null) return;
                if (!CanPlace(window.GetSlot(index), window.pinv.CarriedItem)) 
                    return;
                if (item == null || !ItemEquals(item, CarriedItem))
                    Swap(ref item, ref CarriedItem);
                else
                    TryMove(ref item, ref CarriedItem, CarriedItem.ItemCount);
            }
        }
        public sealed class RightClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                if (item == null && CarriedItem == null) return;
                if (!CanPlace(window.GetSlot(index), window.pinv.CarriedItem)) return;
                if (item == null)
                {
                    //set item with count equal 1 from CI
                    item = (Item)CarriedItem.Clone();
                    item.ItemCount = 0;
                    TryMove(ref item, ref CarriedItem, 1);
                }
                else
                {
                    if (CarriedItem == null)
                    {
                        //grab clicked item with item.count / 2 count.
                        CarriedItem = (Item)item.Clone();
                        CarriedItem.ItemCount = 0;
                        TryMove(ref CarriedItem, ref item, (byte)System.Math.Ceiling(item.ItemCount / 2f));
                    }
                    else
                    {
                        if (ItemEquals(item, CarriedItem))
                        {
                            //add 1
                            TryMove(ref item, ref CarriedItem, 1);
                        }
                        else
                        {
                            //Swap
                            Swap(ref item, ref CarriedItem);
                        }
                    }
                }
            }
        }
        public sealed class DoubleClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                if (item == null && CarriedItem == null) return;
                if (CarriedItem == null) return;
                for (int k = 9; k <= 44; k++)
                {
                    var k_item = window.GetItem(k);
                    if (ItemEquals(k_item, CarriedItem))
                    {
                        TryMove(ref CarriedItem, ref k_item, k_item.ItemCount);
                        window.SetSlot(index, k_item);
                        if (CarriedItem.ItemCount == 64)
                            return;
                    }
                }
            }
        }
        public sealed class NumKeyClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                int newindex = 36 + button;
                if (button == 40)
                    newindex = 45;
                if (!CanPlace(window.GetSlot(index), window.GetSlot(newindex))) return;
                if (index != newindex)
                {
                    var t = window.GetItem(newindex);
                    Swap(ref item, ref t);
                    window.SetSlot(newindex, t);
                }
            }
        }
        public sealed class ShiftClick : AbstractClick
        {
            bool isArmor => index >= 5 && index <= 8;
            bool isMainInv => index >= 9 && index <= 35;
            bool isHotbar => index >= 36 && index <= 44;
            public override void ClickOnSlot(ref Item item)
            {
                if (isArmor)
                    if (!Move(9, 35, ref item))//MainInv
                        Move(36, 44, ref item);//Hotbar
                if (isMainInv)
                    if (!Move(5, 8, ref item))//Armor
                        Move(36, 44, ref item);//Hotbar
                if (isHotbar)
                    if (!Move(5, 8, ref item))//Armor
                        Move(9, 35, ref item);//MainInv
            }
            bool Move(int start, int end, ref Item item)
            {
                if (item == null) return false;
                for (int k = start; k <= end; k++)
                {
                    var k_item = window.GetItem(k);
                    if (k_item != null)
                        TryMove(ref k_item, ref item, item.ItemCount);
                    window.SetSlot(k, k_item);
                    if (item == null) return true;
                }
                for (int k = start; k <= end; k++)
                {
                    var k_slot = window.GetSlot(k);
                    var k_item = k_slot.item;
                    if (k_item == null && CanPlace(k_slot, window.GetSlot(index)))
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
            public override void ClickOnSlot(ref Item item)
            {

            }
        }
    }
}