using System.Collections.Generic;
using MinecraftRPGServer.Properties;

public class SupportedProtocol
{
    public readonly byte[] DimensionCodec;
    public readonly byte[] Dimension;
    public readonly byte[] Tags;


    public SupportedProtocol(byte[] codec, byte[] dim, byte[] Tags)
    {
        DimensionCodec = codec;
        Dimension = dim;
        this.Tags = Tags;
    }

    public static Dictionary<int, SupportedProtocol> allprotocols = new Dictionary<int, SupportedProtocol>()
    {
        {
            757, new SupportedProtocol(
            Resources.DimensionCodec1_18_1,
            Resources.Dimension1_18_1,
            null)
        },
        {
            758, new SupportedProtocol(
            Resources.DimensionCodec1_18_2,
            Resources.Dimension1_18_2,
            Resources.Tags1_18_2)
        },
    };
}