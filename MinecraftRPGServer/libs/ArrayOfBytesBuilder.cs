using System;
public class ArrayOfBytesBuilder
{
    BNode first;
    BNode end;

    public class BNode
    {
        public byte[] Value;
        public BNode next;

        public BNode(byte[] value)
        {
            Value = value;
        }
    }

    public ArrayOfBytesBuilder()
    {
        first = end = new BNode(new byte[0]);
    }

    public void Append(byte[] data)
    {
        end.next = new BNode(data);
        end = end.next;
    }

    public int GetSumLength()
    {
        int l = 0;
        BNode t = first;
        while (t != null)
        {
            l += t.Value.Length;
            t = t.next;
        }
        return l;
    }

    public byte[] ToArray()
    {
        byte[] buffer = new byte[GetSumLength()];
        int offset = 0;
        var t = first;
        while (t != null)
        {
            Buffer.BlockCopy(t.Value, 0, buffer, offset, t.Value.Length);
            offset += t.Value.Length;
            t = t.next;
        }
        return buffer;
    }
}