using Packets.Play;

public struct Sound
{
    public int ID;
    public Categories category;

    public Sound(int iD, Categories category)
    {
        ID = iD;
        this.category = category;
    }
}
