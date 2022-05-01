using System;
using System.Collections.Generic;
using System.Linq;
using Packets.Play;

public abstract class AbstractWindow
{
    public virtual Slot[] Slots => Combine(inventory, player.mainInv, player.hotbar);
    public Slot[] inventory { get; set; }
    public virtual int Type { get; }
    public virtual string Name { get; }
    protected InventoryOfPlayer player;
    public void OnItemChange_Invoke(Item item, int index) => OnItemChanged?.Invoke(item, index);
    public delegate void ItemChangedArgs(Item item, int index);
    public event ItemChangedArgs OnItemChanged;
    public AbstractWindow(InventoryOfPlayer player)
    {
        this.player = player;
    }
    public virtual Item GetItem(int index) => null;
    public virtual void SetSlot(int index, Item newItem) { }
    /// <summary>
    /// Processing packet
    /// </summary>
    /// <param name="packet"></param>
    /// <returns>true if successfuly overwise false</returns>
    public virtual bool ClickWindow(ClickWindow packet)
    {
        void Invoke(ItemMovement.AbstractClick abs, int index)
        {
            var item = GetItem(index);
            abs.CarriedItem = player.CarriedItem.item;
            abs.ClickOnSlot(ref item);
            player.CarriedItem.item = abs.CarriedItem;
            if (player.CarriedItem.item != null && player.CarriedItem.item.ItemCount == 0)
                player.CarriedItem.item = null;
            SetSlot(index, item);
        }

        //bool Add(int index, sbyte count, out byte restCount)
        //{
        //    restCount = 0;
        //    if (count == 0) return false;
        //    var item = GetItem(index);
        //    if (count + item.ItemCount < 0)
        //        throw new System.Exception("Попытка отнять от предмета больше чем допустима");
        //    item.ItemCount = (byte)(item.ItemCount + count);
        //    if (count < 0)
        //    {
        //        if (item.ItemCount <= 0)
        //            item = null;
        //    }
        //    else//count > 0
        //    {
        //        if (item.ItemCount >= 64)
        //        {
        //            restCount = (byte)(item.ItemCount - 64);
        //            item.ItemCount = 64;
        //            return true;
        //        }
        //    }
        //    SetSlot(index, item);
        //    return false;
        //}
        var mode = packet.Mode;
        var button = packet.Button;
        var slot = packet.Slot;
        //bool isArmor(int k) => k >= 5 && k <= 8;
        //bool isHotbar(int k) => k >= 36 && k <= 44;
        //bool isMainInv(int k) => k >= 9 && k <= 35;
        //bool TryMoveItemTo(Item clickedItem, int startindex, int endindex)
        //{
        //    if (clickedItem == null)
        //        return false;
        //    //Try add to exists item
        //    for (int k = startindex; k <= endindex; k++)
        //    {
        //        var k_item = GetItem(k);
        //        if (ItemEquals(clickedItem, k_item))
        //        {
        //            if (Add(k, (sbyte)clickedItem.ItemCount, out var rest))
        //            {
        //                //if k_item_count == 64
        //                clickedItem.ItemCount = rest;
        //                SetSlot(slot, clickedItem);
        //            }
        //            else
        //            {
        //                //if clickedItem_count == 0;
        //                SetSlot(slot, null);
        //                return true;
        //            }
        //        }
        //    }
        //    if (clickedItem.ItemCount == 0)
        //    {
        //        SetSlot(slot, null);
        //        return true;
        //    }
        //    //place in empty slot
        //    for (int k = startindex; k <= endindex; k++)
        //    {
        //        var item = GetItem(k);
        //        if (item == null)
        //        {
        //            SetSlot(k, clickedItem);
        //            SetSlot(slot, null);
        //            return true;
        //        }
        //    }
        //    if (clickedItem.ItemCount == 0)
        //    {
        //        SetSlot(slot, null);
        //        return true;
        //    }
        //    return false;
        //}

        Console.WriteLine($"mode={mode}, button={button}, slot={slot}, GetItem(slot)={(Slot)GetItem(slot)}, CI={(Slot)player.CarriedItem.item}");
        switch (mode)
        {
            case 0:
                if (button == 0)
                {
                    if (slot == -999)
                    {
                        //Drop CI
                        return true;
                    }
                    Invoke(ItemMovement.left, slot);
                    return true;
                }
                else if (button == 1)
                {
                    if (slot == -999)
                    {
                        //Drop 1 item from CI
                        return true;
                    }
                    Invoke(ItemMovement.right, slot);
                    return true;
                }
                break;
            case 1:
                ////Shift + left mouse click
                //{
                //    var clicked = GetItem(slot);
                //    if (clicked == null) break;

                //    if (isHotbar(slot))
                //    {
                //        if (!TryMoveItemTo(clicked, 5, 8))//Move to armor
                //            TryMoveItemTo(clicked, 9, 35);//Move item to mainInv
                //        break;
                //    }
                //    if (isArmor(slot))
                //    {
                //        if (!TryMoveItemTo(clicked, 36, 44))//Move item to hotbar
                //            TryMoveItemTo(clicked, 9, 35);//Move item to mainInv
                //        break;
                //    }
                //    if (isMainInv(slot))
                //    {
                //        if (!TryMoveItemTo(clicked, 5, 8))//Move to armor
                //            TryMoveItemTo(clicked, 36, 44);//Move item to hotbar
                //        break;
                //    }
                //    if (!TryMoveItemTo(clicked, 36, 44))//Move item to hotbar
                //        TryMoveItemTo(clicked, 9, 35);//Move item to mainInv
                //}
                break;
            case 2:
                break;
        }
        return false;
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
        public static LeftClick left = new LeftClick();
        public static RightClick right = new RightClick();
        public abstract class AbstractClick
        {
            public int index;
            public SlotType slotType;
            public Item CarriedItem;
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
    }
}