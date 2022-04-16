[Item("minecraft:apple")]
public class Apple : Item, IUsable
{
    public Apple()
    {

    }

    public void Use(Player player)
    {
        player.EchoIntoChatFromServer("use");
    }
}
