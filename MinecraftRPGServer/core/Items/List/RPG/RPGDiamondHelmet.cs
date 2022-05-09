namespace Inventory.Items
{
    [RPGItem("diamond_helmet")]
    public class RPGDiamondHelmet : DiamondHelmet
    {
        public override string[] Lore => new string[]
        {
            $"Type: Helmet",
            $"Health: {Health}",
        };
        public RPGDiamondHelmet()
        {
            Health = 20;
            Name = "diamond helmet";
        }
    }
}