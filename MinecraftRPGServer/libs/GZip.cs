using System.IO;
using System.IO.Compression;

public static class GZip
{
    public static byte[] Decompress(byte[] data, int offset = 0)
    {
        using (var @out = new MemoryStream())
        using (var @in = new MemoryStream(data, offset, data.Length - offset))
        using (var gzip = new GZipStream(@in, CompressionMode.Decompress))
        {
            gzip.CopyTo(@out);
            gzip.Close();
            @out.Position = 0;
            return @out.ToArray();
        }
    }
    public static byte[] Compress(byte[] data, int offset = 0)
    {
        using (MemoryStream @out = new MemoryStream())
        using (var @in = new MemoryStream(data, offset, data.Length - offset))
        using (var gzip = new GZipStream(@in, CompressionMode.Compress))
        {
            @out.CopyTo(gzip);
            @out.Close();
            return @out.ToArray();
        }
    }
}