using System;
using System.Collections.Generic;
using System.Linq;
using Packets.Play;

public abstract class AbstractWindow
{
    public virtual Slot[] Slots => Combine(inventory, pinv.mainInv, pinv.hotbar);
    public Slot[] inventory { get; set; }
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
    public virtual Item GetItem(int index) => null;
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
                        Invoke(ItemMovement.leftClick);
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
                        Invoke(ItemMovement.rightClick);
                        break;
                    }
                    break;
                case 1://Shift + left mouse click
                    break;
                case 2://Number key {BUTTON}
                       //if Button == 40 it is Offhand swap key F
                    Invoke(ItemMovement.numKeyClick);
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
                    break;
                case 6://Double click
                    if (button == 0)
                        Invoke(ItemMovement.doubleClick);
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
            .Select(x => x is Item[] arr ? arr : new Item[] { x as Item })
            .SelectMany(x => x)
            .Select(x => (Slot)x)
            .ToArray();
    }
    public class ItemMovement
    {
        public static LeftClick leftClick = new LeftClick();
        public static RightClick rightClick = new RightClick();
        public static DoubleClick doubleClick = new DoubleClick();
        public static NumKeyClick numKeyClick = new NumKeyClick();
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
        }
        public class LeftClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                if (item == null && CarriedItem == null) return;
                if (item == null || !ItemEquals(item, CarriedItem))
                    Swap(ref item, ref CarriedItem);
                else
                    TryMove(ref item, ref CarriedItem, CarriedItem.ItemCount);
            }
        }
        public class RightClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                if (item == null && CarriedItem == null) return;
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
        public class DoubleClick : AbstractClick
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
        public class NumKeyClick : AbstractClick
        {
            public override void ClickOnSlot(ref Item item)
            {
                int newindex = 36 + button;
                if (button == 40)
                    newindex = 45;
                if (index != newindex)
                {
                    var t = window.GetItem(newindex);
                    Swap(ref item, ref t);
                    window.SetSlot(newindex, t);
                }
            }
        }
    }
}