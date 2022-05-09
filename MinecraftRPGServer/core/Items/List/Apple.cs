namespace Inventory.Items
{
    [Item(ItemID.apple)]
    public class Apple : Item, IUsable
    {
        public void Use(Player player)
        {
            player.EchoIntoChatFromServer("use");
        }
    }

}