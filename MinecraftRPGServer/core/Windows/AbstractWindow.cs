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
        bool ItemEquals(Item a, Item b) => 
            a != null && b != null && 
            a.ItemID.value == b.ItemID.value && 
            a.NBT.Bytes.SequenceEqual(b.NBT.Bytes);
        bool Add(int index, byte count, out byte restCount)
        {
            restCount = 0;
            if (count == 0) return false;
            var item = GetItem(index);
            item.ItemCount += count;
            if (count < 0)
            {
                if (item.ItemCount <= 0)
                    item = null;
            }
            else//count > 0
            {
                if (item.ItemCount >= 64)
                {
                    restCount = (byte)(item.ItemCount - 64);
                    item.ItemCount = 64;
                    return true;
                }
            }
            SetSlot(index, item);
            return false;
        }
        void LeftClickOnSlot(int index)
        {
            if (ItemEquals(GetItem(index), player.CarriedItem))
            {
                if (Add(index, player.CarriedItem.ItemCount, out var rest))
                    player.CarriedItem.ItemCount = rest;
                else
                    player.CarriedItem = null;
                return;
            }
            SwapWithCI(index);
        }
        void RightClickOnSlot(int index)
        {
            var item = GetItem(index);
            if (item == null)
            {
                //place 1 item from CI
                var newItem = (Item)player.CarriedItem.Clone();
                newItem.ItemCount = 1;
                player.CarriedItem.ItemCount -= 1;
                if (player.CarriedItem.ItemCount <= 0)
                    player.CarriedItem = null;
                SetSlot(index, newItem);
                return;
            }
            else
            {
                if (item.ItemCount < 64 && ItemEquals(item, player.CarriedItem))
                {
                    //add 1 item from CI to item
                    item.ItemCount += 1;
                    player.CarriedItem.ItemCount -= 1;
                    if (player.CarriedItem.ItemCount <= 0)
                        player.CarriedItem = null;
                    SetSlot(index, item);
                    return;
                }
                else if (player.CarriedItem == null)
                {
                    //add half to CI from item
                    player.CarriedItem = (Item)item.Clone();
                    item.ItemCount /= 2;
                    player.CarriedItem.ItemCount -= item.ItemCount;
                    SetSlot(index, item);
                }
            }
        }
        void SwapWithCI(int index)
        {
            var item = GetItem(index);
            var t = player.CarriedItem;
            player.CarriedItem = item;
            SetSlot(index, t);
        }

        var mode = packet.Mode;
        var button = packet.Button;
        var slot = packet.Slot;
        bool isArmor(int k) => k >= 5 && k <= 8;
        bool isHotbar(int k) => k >= 36 && k <= 44;
        bool isMainInv(int k) => k >= 9 && k <= 35;
        bool TryMoveItemTo(Item clickedItem, int startindex, int endindex)
        {
            if (clickedItem == null)
                return false;
            //Try add to exists item
            for (int k = startindex; k <= endindex; k++)
            {
                var k_item = GetItem(k);
                if (ItemEquals(clickedItem, k_item))
                {
                    if (Add(k, clickedItem.ItemCount, out var rest))
                    {
                        //if k_item_count == 64
                        clickedItem.ItemCount = rest;
                        SetSlot(slot, clickedItem);
                    }
                    else
                    {
                        //if clickedItem_count == 0;
                        SetSlot(slot, null);
                        return true;
                    }
                }
            }
            if (clickedItem.ItemCount == 0)
            {
                SetSlot(slot, null);
                return true;
            }
            //place in empty slot
            for (int k = startindex; k <= endindex; k++)
            {
                var item = GetItem(k);
                if (item == null)
                {
                    SetSlot(k, clickedItem);
                    SetSlot(slot, null);
                    return true;
                }
            }
            if (clickedItem.ItemCount == 0)
            {
                SetSlot(slot, null);
                return true;
            }
            return false;
        }

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
                    LeftClickOnSlot(slot);
                    return true;
                }
                else if (button == 1)
                {
                    if (slot == -999)
                    {
                        //Drop 1 item from CI
                        return true;
                    }
                    RightClickOnSlot(slot);
                    return true;
                }
                break;
            case 1:
                //Shift + left mouse click
                {
                    var clicked = GetItem(slot);
                    if (clicked == null) break;

                    if (isHotbar(slot))
                    {
                        if (!TryMoveItemTo(clicked, 5, 8))//Move to armor
                            TryMoveItemTo(clicked, 9, 35);//Move item to mainInv
                        break;
                    }
                    if (isArmor(slot))
                    {
                        if (!TryMoveItemTo(clicked, 36, 44))//Move item to hotbar
                            TryMoveItemTo(clicked, 9, 35);//Move item to mainInv
                        break;
                    }
                    if (isMainInv(slot))
                    {
                        if (!TryMoveItemTo(clicked, 5, 8))//Move to armor
                            TryMoveItemTo(clicked, 36, 44);//Move item to hotbar
                        break;
                    }
                    if (!TryMoveItemTo(clicked, 36, 44))//Move item to hotbar
                        TryMoveItemTo(clicked, 9, 35);//Move item to mainInv
                }
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
}
