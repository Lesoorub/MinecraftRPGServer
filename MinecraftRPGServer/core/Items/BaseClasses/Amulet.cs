using Newtonsoft.Json;

namespace Inventory.Items
{
    public class Amulet : GlisteringMelonSlice, IContainer
    {
        public override string Type => "Amulet";

        public Scroll Scroll { get => slots[13].item as Scroll; set => slots[13].item = value; }
        [JsonIgnore]
        public IndexedItem[] slots { get; set; } = new IndexedItem[27];
        public Amulet()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i == 13)
                {
                    slots[i] = new IndexedItem(Scroll, new string[] { "scroll" });
                    continue;
                }
                slots[i] =
                    new IndexedItem(
                        WhiteStainedGlassPane.Instance,
                        new string[] { "readonly" })
                    {
                        readOnly = true
                    };
            }
        }

        public void OpenWindow(Player player)
        {
            player.OpenWindow(new ChestWindow(player.inventory, slots)
            {
                WindowTitle = Chat.ColoredText("&8Select sroll")
            });
        }
    }

    public interface IContainer
    {
        IndexedItem[] slots { get; set; }
        void OpenWindow(Player player);
    }
}