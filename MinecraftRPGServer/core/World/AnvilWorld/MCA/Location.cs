public partial class MCA
{
    public struct Location
    {
        /// <summary>
        /// Смещение относительно начала файла в страницах
        /// </summary>
        public int Offset;
        /// <summary>
        /// Размер в страницах
        /// </summary>
        public byte Size;

        public bool isValid => Offset != 0 || Size != 0;

        public Location(int offset, byte size)
        {
            Offset = offset;
            Size = size;
        }

        public Location(byte[] bytes, int offset)
        {
            Offset =
                bytes[offset + 0] << 16 |
                bytes[offset + 1] << 8 |
                bytes[offset + 2];
            Size = bytes[offset + 3];
        }

        public void Write(byte[] bytes, int offset)
        {
            bytes[offset + 0] = (byte)(Offset >> 16 & 0xFF);
            bytes[offset + 1] = (byte)(Offset >> 8 & 0xFF);
            bytes[offset + 2] = (byte)(Offset & 0xFF);
            bytes[offset + 3] = Size;
        }
        public byte[] ToBytes()
        {
            var bytes = new byte[4];
            Write(bytes, 0);
            return bytes;
        }
    }
}


//namespace SpaceMan
//{
//    public static class SpaceUtil
//    {
//        public int GetEmptyPage(byte[] )
//    }
//}