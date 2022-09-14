namespace Inventory.Items
{
    [Item(ItemNameID.apple)]
    public class Apple : Item, IUsable
    {
        public void Use(Player player)
        {
            player.EchoIntoChatFromServer("use");
        }
    }
}