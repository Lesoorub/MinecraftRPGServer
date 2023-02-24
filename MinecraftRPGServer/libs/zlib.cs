using System;
using Ionic.Zlib;

namespace Compressions
{
    public static class zlib
    {
        public static bool TryDecompress(byte[] compressed, out byte[] decomressed)
        {
            try
            {
                decomressed = ZlibStream.UncompressBuffer(compressed);
            }
            catch// (Exception ex)
            {
                decomressed = null;
                return false;
            }
            return true;
        }
        public static bool TryCompress(byte[] uncompressed, out byte[] compressed)
        {
            try
            {
                compressed = ZlibStream.CompressBuffer(uncompressed);
            }
            catch// (Exception ex)
            {
                compressed = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ZlibException">Bad state</exception>
        /// <param name="compressed"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [Obsolete("Use TryDecompress")]
        public static byte[] Decompress(byte[] compressed)
        {
            return ZlibStream.UncompressBuffer(compressed);
        }
        /// <summary>
        /// </summary>
        /// <exception cref="ZlibException">Bad state</exception>
        /// <param name="compressed"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [Obsolete("Use TryCompress")]
        public static byte[] Compress(byte[] uncompressed)
        {
            return ZlibStream.CompressBuffer(uncompressed);
        }
    }

}
