using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;
using MineServer;
public static class zlib
{
    public static byte[] Decompress(byte[] compressed, int offset = 0)
    {
        int outputSize = 2048;
        byte[] output = new Byte[outputSize];

        // If you have a ZLIB stream, set this to true.  If you have
        // a bare DEFLATE stream, set this to false.
        bool expectRfc1950Header = true;

        using (MemoryStream ms = new MemoryStream())
        {
            ZlibCodec compressor = new ZlibCodec();
            compressor.InitializeInflate(expectRfc1950Header);

            compressor.InputBuffer = compressed;
            compressor.AvailableBytesIn = compressed.Length;
            compressor.NextIn = 0;
            compressor.OutputBuffer = output;

            foreach (var f in new FlushType[] { FlushType.None, FlushType.Finish })
            {
                int bytesToWrite = 0;
                do
                {
                    compressor.AvailableBytesOut = outputSize;
                    compressor.NextOut = 0;
                    compressor.Inflate(f);

                    bytesToWrite = outputSize - compressor.AvailableBytesOut;
                    if (bytesToWrite > 0)
                        ms.Write(output, 0, bytesToWrite);
                }
                while ((f == FlushType.None && (compressor.AvailableBytesIn != 0 || compressor.AvailableBytesOut == 0)) ||
                       (f == FlushType.Finish && bytesToWrite != 0));
            }

            compressor.EndInflate();

            return ms.ToArray();
        }

        //using (var @out = new MemoryStream())
        //using (var @in = new MemoryStream(data, offset, data.Length - offset))
        //using (var zlib = new DeflateStream(@in, CompressionMode.Decompress))
        //{
        //    zlib.CopyTo(@out);
        //    zlib.Close();
        //    @out.Position = 0;
        //    return @out.ToArray();
        //}

        //using (var @out = new MemoryStream())
        //using (var @in = new MemoryStream(compressed, offset, compressed.Length - offset))
        //using (var zlib = new ZlibStream(@in, Ionic.Zlib.CompressionMode.Decompress, Ionic.Zlib.CompressionLevel.Level6))
        //{
        //    zlib.CopyTo(@out);
        //    zlib.Close();
        //    @out.Position = 0;
        //    return @out.ToArray();
        //}
    }
    public static byte[] Decompress2(byte[] data)
    {
        return Decompress(data);
        //return Decompress(data.Skip(2));
    }
    public static byte[] Compress(byte[] uncompressed, int offset = 0)
    {
        int outputSize = 2048;
        byte[] output = new Byte[outputSize];
        int lengthToCompress = uncompressed.Length;

        // If you want a ZLIB stream, set this to true.  If you want
        // a bare DEFLATE stream, set this to false.
        bool wantRfc1950Header = true;

        using (MemoryStream ms = new MemoryStream())
        {
            ZlibCodec compressor = new ZlibCodec();
            compressor.InitializeDeflate(Ionic.Zlib.CompressionLevel.BestCompression, wantRfc1950Header);

            compressor.InputBuffer = uncompressed;
            compressor.AvailableBytesIn = lengthToCompress;
            compressor.NextIn = 0;
            compressor.OutputBuffer = output;

            foreach (var f in new FlushType[] { FlushType.None, FlushType.Finish })
            {
                int bytesToWrite = 0;
                do
                {
                    compressor.AvailableBytesOut = outputSize;
                    compressor.NextOut = 0;
                    compressor.Deflate(f);

                    bytesToWrite = outputSize - compressor.AvailableBytesOut;
                    if (bytesToWrite > 0)
                        ms.Write(output, 0, bytesToWrite);
                }
                while ((f == FlushType.None && (compressor.AvailableBytesIn != 0 || compressor.AvailableBytesOut == 0)) ||
                       (f == FlushType.Finish && bytesToWrite != 0));
            }

            compressor.EndDeflate();

            ms.Flush();
            return ms.ToArray();
        }

        //using (var @out = new MemoryStream())
        //using (var @in = new MemoryStream(data, offset, data.Length - offset))
        //using (var zlib = new DeflateStream(@out, CompressionMode.Compress))
        //{
        //    @in.CopyTo(zlib);
        //    zlib.Close();
        //    return @out.ToArray();
        //}
    }
}
