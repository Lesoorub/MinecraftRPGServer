using System;
using NBT;
using Newtonsoft.Json;

namespace MineServer
{
    public struct VarInt : ISerializable, IDeserializable
    {
        public int value;
        [JsonIgnore]
        public byte length
        {
            get
            {
                byte index = 0;
                int v = value;
                do
                {
                    v = (int)((uint)v >> 7);
                    index++;
                } while (v != 0);
                return index;
            }
        }
        [JsonIgnore]
        public byte[] Bytes
        {
            get
            {
                byte[] buffer = new byte[8];
                int index = 0;
                int v = value;
                do
                {
                    byte currentByte = (byte)(v & 0b01111111);
                    v = (int)((uint)v >> 7);
                    if (v != 0) currentByte |= 0b10000000;
                    buffer[index++] = currentByte;
                } while (v != 0);
                return buffer.Take(index);
            }
        }
        public VarInt(int value)
        {
            this.value = value;
        }
        public VarInt(byte[] buffer, int offset)
        {
            value = readVarInt(buffer, offset);
        }
        public VarInt(byte[] buffer, ref int offset)
        {
            value = 0;
            value = readVarInt(buffer, offset);
            offset += length;
        }
        static int readVarInt(byte[] buffer, int offset) => readVarInt(buffer, offset, out int _);
        static int readVarInt(byte[] buffer, int offset, out int length)
        {
            byte numRead = 0;
            int result = 0;
            byte read;
            do
            {
                if (offset + numRead >= buffer.Length)
                    throw new Exception("Is too big");
                read = buffer[offset + numRead];
                int value = (read & 0b01111111);
                result |= (value << (7 * numRead));

                numRead++;
                if (numRead > 5)
                    throw new Exception("Is too big");
            } while ((read & 0b10000000) != 0);
            length = numRead;
            return result;
        }
        public static int Get(byte[] raw, ref int offset)
        {
            var t = readVarInt(raw, offset, out var len);
            offset += len;
            return t;
        }
        public static int Get(byte[] raw, int offset)
        {
            return readVarInt(raw, offset);
        }
        public static implicit operator VarInt(int t) => new VarInt(t);
        public static implicit operator int(VarInt t) => t.value;
        public static implicit operator byte[](VarInt t) => t.Bytes;
        public static bool operator ==(VarInt a, VarInt b) => a.value == b.value;
        public static bool operator !=(VarInt a, VarInt b) => a.value != b.value;
        public static bool operator ==(VarInt a, int b) => a.value == b;
        public static bool operator !=(VarInt a, int b) => a.value != b;
        public static bool operator ==(int a, VarInt b) => b.value == a;
        public static bool operator !=(int a, VarInt b) => b.value != a;
        public override bool Equals(object obj)
        {
            return obj is VarInt a && a == this;
        }
        public override string ToString()
        {
            return value.ToString();
        }

        public byte[] ToByteArray() => Bytes;
        public static byte[] ArrayOfVarIntsToByteArray(VarInt[] arr)
        {
            byte[] buffer = new byte[arr.Length * 4 + 4];
            var len = new VarInt(arr.Length).Bytes;
            Buffer.BlockCopy(len, 0, buffer, 0, len.Length);
            int offset = len.Length;
            int value;
            for (int k = 0; k < arr.Length; k++)
            {
                value = arr[k];
                do
                {
                    byte currentByte = (byte)(value & 0b01111111);
                    value = (int)((uint)value >> 7);
                    if (value != 0) currentByte |= 0b10000000;
                    buffer[offset++] = currentByte;
                } while (value != 0);
            }
            return buffer.Take(offset);
        }
        public void FromByteArray(byte[] bytes, int offset, out int length)
        {
            value = readVarInt(bytes, offset);
            length = this.length;
        }

        public override int GetHashCode()
        {
            return -1584136870 + value.GetHashCode();
        }
    }
}