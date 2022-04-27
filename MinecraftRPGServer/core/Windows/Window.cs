using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using Packets.Play;

public class Window
{
    public virtual int WindowID { get; }
    public virtual Item[] slots { get; set; }
    public Item CarriedItem = new Item();
    public virtual bool canMoveItems { get; } = true;
    public virtual int MainInvOffset { get; } = 9;
    public virtual int HotBarOffset { get; } = 36;
    public delegate void ClickArgs(int index, int button, int mode, bool shift);
    public delegate void StackArgs(Item item, int index);
    public delegate void KeyArgs(int index, int key);
    public delegate void SlotArgs(Item slot);
    public event StackArgs OnSlotChanged;
    public event ClickArgs OnClick;
    public event ClickArgs OnDoubleClick;
    public event KeyArgs OnPressKey;
    public event SlotArgs OnDropStack;

    /// <summary>
    /// Processing packet
    /// </summary>
    /// <param name="packet">parsed packet</param>
    /// <returns>Need full update inventory</returns>
    public bool ClickWindow(ClickWindow packet)
    {
        sbyte Button = packet.Button;//left/right
        short Slot = packet.Slot;//clicked slot
        int Mode = packet.Mode;
        var ArrayOfSlots = packet.Slots;
        Slot ClickedItem = packet.ClickedItem;

        if (Mode == 0 || Mode == 1)
            OnClick?.Invoke(Slot, Button, Mode, Mode == 1);
        if (Mode == 2)
            OnPressKey?.Invoke(Slot, Button);
        if (Mode == 3)
            OnClick?.Invoke(Slot, Button, Mode, false);
        if (Mode == 4 && slots != null && Slot > 0)
            OnDropStack?.Invoke(slots[Slot]);
        if (Mode == 6)
            OnDoubleClick?.Invoke(Slot, Button, Mode, false);

        //Console.WriteLine($"S:{Slot}, B:{Button}, M:{Mode}, iSlots:{string.Join(",", ArrayOfSlots.Select(x => x.ToString()))}, H:{ClickedItem}");

        if (!canMoveItems)
            return false;

        if (Slot == -1)
        {
            //Click on inventory
            //do nothing
            return true;
        }
        if (Slot == -999 && Mode == 0 &&
            CarriedItem.Present && CarriedItem.ItemCount > 0 && (Button == 0 || Button == 1))//drop item
        {
            var dropped = new Slot(CarriedItem.ItemID,
                (byte)(Button == 0 ? CarriedItem.ItemCount : 1), CarriedItem.NBT);
            CarriedItem.ItemCount -= dropped.ItemCount;
            if (CarriedItem.ItemCount <= 0)
                CarriedItem = default;
            OnDropStack?.Invoke(dropped);
            return true;
        }

        //calculate items count
        int Hash(Slot slot)
        {
            if (!slot.Present) return 0;
            return slot.ItemID.GetHashCode() * (slot.NBT == null ? 1 : slot.NBT.GetHashCode());
        }

        var sendedItems = new SortedDictionary<int, int>();
        var realItems = new SortedDictionary<int, int>();
        void Add(SortedDictionary<int, int> dict, Slot slot)
        {
            var hash = Hash(slot);
            if (hash == 0) return;
            if (dict.ContainsKey(hash))
                dict[hash] += slot.ItemCount;
            else
                dict.Add(hash, slot.ItemCount);
        }
        foreach (var indexedSlot in ArrayOfSlots)
        {
            Add(sendedItems, indexedSlot.data);
            if (slots[indexedSlot.index] != null)
                Add(realItems, slots[indexedSlot.index]);
        }
        Add(realItems, CarriedItem);
        Add(sendedItems, ClickedItem);


        //main check items equals
        if (!(sendedItems.Count == realItems.Count && sendedItems.SequenceEqual(realItems)))
        {
            Console.WriteLine("realItems: " + realItems.Count);
            foreach (var t in realItems)
                Console.WriteLine(t);
            Console.WriteLine("sendedItems: " + sendedItems.Count);
            foreach (var t in sendedItems)
                Console.WriteLine(t);
            return false;
        }

        //apply all client data
        foreach (var indexedSlot in ArrayOfSlots)
        {
            SetSlot(indexedSlot.index, indexedSlot.data);
        }
        CarriedItem = ClickedItem;
        return true;
    }

    public void SetSlot(int index, Slot data)
    {
        if (index != -1)
        {
            slots[index] = data;
            OnSlotChanged?.Invoke(slots[index], index);
        }
        else
            OnSlotChanged?.Invoke(null, index);
    }
    public int FindItem(string nameid)
    {
        int itemid = Item.NameIDs[nameid];
        for (int k = 0; k < slots.Length; k++)
        {
            if (slots[k] == null || !slots[k].Present || slots[k].ItemID != itemid) continue;
            return k;
        }
        return -1;
    }
}
