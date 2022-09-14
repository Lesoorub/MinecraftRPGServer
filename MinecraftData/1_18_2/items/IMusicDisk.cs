namespace MinecraftData._1_18_2.items.minecraft
{
    public interface IMusicDisk
    {
        byte analog_output { get; } //[0, 1, ... , 13]
        short sound { get; }
    }

}
