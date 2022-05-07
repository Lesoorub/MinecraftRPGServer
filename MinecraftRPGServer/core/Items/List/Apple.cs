namespace Inventory.Items
{
    [Item("minecraft:apple")]
    public class Apple : Item, IUsable
    {
        public void Use(Player player)
        {
            player.EchoIntoChatFromServer("use");
        }
    }

}