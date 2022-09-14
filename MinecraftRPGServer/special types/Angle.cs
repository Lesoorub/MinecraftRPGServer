using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using NBT;

public struct Angle : ISerializable, IDeserializable
{
    private byte Data;
    public float Value { get => (Data / 256f) * 360f; set => Data = (byte)Math.Round((value / 360f) * 256); }

    public Angle(byte data)
    {
        this.Data = data;
    }
    public Angle(float value)
    {
        Data = 0;
        Value = value;
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        Data = bytes[offset];
        length = 1;
    }

    public byte[] ToByteArray()
    {
        return new byte[] { Data };
    }
}
