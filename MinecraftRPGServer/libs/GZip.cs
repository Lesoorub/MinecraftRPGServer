using System;
using System.IO;
using System.IO.Compression;

namespace Compressions
{
    public static class GZip
    {
        public static bool TryDecompress(byte[] compressed, out byte[] decompressed)
        {
            try
            {
                decompressed = Decompress(compressed);
                return true;
            }
            catch// (Exception ex)
            {
                decompressed = null;
                return false;
            }
        }
        public static bool TryCompress(byte[] decompressed, out byte[] compressed)
        {
            try
            {
                compressed = Compress(decompressed);
                return true;
            }
            catch// (Exception ex)
            {
                compressed = null;
                return false;
            }
        }
        public static byte[] Decompress(byte[] compressed)
        {
            using (var @out = new MemoryStream())
            using (var @in = new MemoryStream(compressed, 0, compressed.Length))
            using (var gzip = new GZipStream(@in, CompressionMode.Decompress))
            {
                gzip.CopyTo(@out);
                gzip.Close();
                @out.Position = 0;
                return @out.ToArray();
            }
        }
        public static byte[] Compress(byte[] decompressed)
        {
            using (MemoryStream @out = new MemoryStream())
            using (var @in = new MemoryStream(decompressed, 0, decompressed.Length))
            using (var gzip = new GZipStream(@in, CompressionMode.Compress))
            {
                @out.CopyTo(gzip);
                @out.Close();
                return @out.ToArray();
            }
        }
    }
}