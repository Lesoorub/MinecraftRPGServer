using MineServer;
using Packets.Play;

public static class PlayerTitle
{
    public static void SetTitles(NetworkProvider network, Chat text, int fadein, int duration, int fadeout)
    {
        network.Send(new SetTitleText()
        {
            TitleText = text
        });
        network.Send(new SetTitleTimes()
        {
            FadeIn = fadein,
            Stay = duration,
            FadeOut = fadeout,
        });
    }
}