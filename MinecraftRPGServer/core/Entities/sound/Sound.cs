using Packets.Play;

public struct Sound
{
    public SoundID ID;
    public Categories category;

    public Sound(SoundID ID, Categories category)
    {
        this.ID = ID;
        this.category = category;
    }
}
