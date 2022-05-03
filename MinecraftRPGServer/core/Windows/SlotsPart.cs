using System;
[Obsolete("See player inventory v2.0")]
public class SlotsPart
{
    private PlayerInventory inv;
    private int start;
    private int len;
    public Item this[int index]
    {
        get => (index < len && index >= 0) ?
        inv.slots[start + index] :
        throw new IndexOutOfRangeException("Hotbar length = 9. Try acces to " + index);
        set
        {
            inv.slots[start + index] = value;
            OnSlotChanged?.Invoke(index, start + index, value);
        }
    } 

    public delegate void SlotChangedArgs(int local_index, int absolute_index, Item newitem);
    public event SlotChangedArgs OnSlotChanged;
    public SlotsPart(PlayerInventory inv, int start, int len)
    {
        this.inv = inv;
        this.start = start;
        this.len = len;
    }
}