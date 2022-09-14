//Documentation https://wiki.vg/NBT
namespace NBT
{
    public interface IDeserializable
    {
        void FromByteArray(byte[] bytes, int offset, out int length);
    }
}