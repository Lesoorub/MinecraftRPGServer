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
        void Swap(ref Item a, ref Item b)
        {
            var t = a;
            a = b;
            b = t;
        }

        var mode = packet.Mode;
        var button = packet.Button;
        var slot = packet.Slot;

        switch (mode)
        {
            case 0:
                if (button == 0)
                {
                    var item = GetItem(slot);
                    Swap(ref player.CarriedItem, ref item);
                    return true;
                }
                else if (button == 1)
                {

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
