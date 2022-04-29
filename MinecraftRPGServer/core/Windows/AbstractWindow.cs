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
            a != null && 
            b != null && 
            a.ItemID.value == b.ItemID.value && 
            a.NBT.Bytes.SequenceEqual(b.NBT.Bytes);
        void LeftClickOnSlot(int index)
        {
            var item = GetItem(index);
            if (ItemEquals(item, player.CarriedItem))
            {
                item.ItemCount += player.CarriedItem.ItemCount;
                if (item.ItemCount > 64)
                {
                    player.CarriedItem.ItemCount = (byte)(item.ItemCount - 64);
                    item.ItemCount = 64;
                }
                else
                    player.CarriedItem = null;
                SetSlot(index, item);
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
                var newItem = (Item)item.Clone();
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

        switch (mode)
        {
            case 0:
                if (button == 0)
                {
                    LeftClickOnSlot(slot);
                    return true;
                }
                else if (button == 1)
                {
                    RightClickOnSlot(slot);
                    return true;
                }
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
