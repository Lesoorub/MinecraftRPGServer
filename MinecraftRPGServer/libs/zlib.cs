using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using MineServer;
public static class zlib
{
    public static byte[] Decompress(byte[] data, int offset = 0)
    {
        using (var @out = new MemoryStream())
        using (var @in = new MemoryStream(data, offset, data.Length - offset))
        using (var zlib = new DeflateStream(@in, CompressionMode.Decompress))
        {
            zlib.CopyTo(@out);
            zlib.Close();
            @out.Position = 0;
            return @out.ToArray();
        }
    }
    public static byte[] Decompress2(byte[] data)
    {
        return Decompress(data.Skip(2).Combine(data.Take(data.Length - 4, 4)));
    }
    public static byte[] Compress(byte[] data, int offset = 0)
    {
        using (var @out = new MemoryStream())
        using (var @in = new MemoryStream(data, offset, data.Length - offset))
        using (var zlib = new DeflateStream(@out, CompressionMode.Compress))
        {
            @in.CopyTo(zlib);
            zlib.Close();
            return @out.ToArray();
        }
    }
}