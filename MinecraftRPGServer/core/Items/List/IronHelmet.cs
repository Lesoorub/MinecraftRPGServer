namespace Items
{
    [Item("minecraft:iron_helmet")]
    public class IronHelmet : Helmet
    {
        public override SlotType allowedType => SlotType.Armor | SlotType.Helmet;
        public IronHelmet()
        {
            Health = 10;
        }
    }

}