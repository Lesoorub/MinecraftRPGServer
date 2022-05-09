using System.Collections.Generic;
using MineServer;

public sealed class MinecraftPacket
{
    public VarInt packet_len;
    public VarInt packet_id;
    public byte[] data;

    public MinecraftPacket(byte[] raw, ref int offset)
    {
        ArrayReader reader = new ArrayReader(raw, offset);
        packet_len = reader.ReadVarInt();
        packet_id = reader.ReadVarInt();
        data = reader.ReadBytes(packet_len - packet_id.length);
        offset = reader.offset;
    }

    public MinecraftPacket(VarInt packet_len, VarInt packet_id, byte[] data)
    {
        this.packet_len = packet_len;
        this.packet_id = packet_id;
        this.data = data;
    }

    public static MinecraftPacket[] Parse(BytesBasedPacket packet)
    {
        ArrayReader reader = new ArrayReader(packet.data);
        List<MinecraftPacket> list = new List<MinecraftPacket>();
        do
        {
            if (reader.buffer[reader.offset] == 0xFE && reader.buffer[reader.offset + 1] == 0x01)
            {
                reader.ReadBytes(2);//Skip 2 bytes
                continue;
            }
            VarInt packet_len = reader.ReadVarInt();
            if (packet_len > 2097151 ||
                packet_len < 1 ||
                packet_len > packet.data.Length - reader.offset)
            {
#if DEBUG
                System.Console.WriteLine($"[Err] " + packet.data.ToDump());
#endif
                break;
            }
            VarInt packet_id = reader.ReadVarInt();
            byte[] data = reader.ReadBytes(packet_len - packet_id.length);
#if DEBUG
            //System.Console.WriteLine("[C->S] " +
            //    packet.data.Take(
            //        reader.offset - packet_len - packet_len.length, 
            //        packet_len + packet_len.length).ToDump());
#endif
            list.Add(new MinecraftPacket(packet_len, packet_id, data));
        }
        while (!reader.isEnd);
        return list.ToArray();
    }
}
