using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MineServer;

public struct RawByteArray : ISerializable, IDeserializable
{
    public byte[] bytes;

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        this.bytes = bytes.Skip(offset);
        length = bytes.Length;
    }

    public byte[] ToByteArray()
    {
        return bytes;
    }

    public static implicit operator byte[] (RawByteArray t) => t.bytes;
    public static implicit operator RawByteArray(byte[] t) => new RawByteArray() { bytes = t };
}