using System.Collections.Generic;

namespace Inventory.Items
{
    [RPGItem("backpack")]
    public class Backpack : Leather, IContainer, IUsable
    {
        public IndexedItem[] slots { get; set; } = new IndexedItem[27];
        public override CustomModelData model => CustomModelData.backpack0;
        public override List<string> GetOreDict()
        {
            var t = base.GetOreDict();
            t.Add("minecraft:backpack");
            return t;
        }
        public override byte MaxCount => 1;
        public void OpenWindow(Player player)
        {
            for (int k = 0; k < slots.Length; k++)
            {
                slots[k].blacklistItems = new string[] { "minecraft:backpack" };
            }
            player.OpenWindow(new ChestWindow(player.inventory, slots)
            {
                WindowTitle = Chat.ColoredText("&8Backpack")
            });
        }

        public void Use(Player player)
        {
            OpenWindow(player);
        }
    }
}