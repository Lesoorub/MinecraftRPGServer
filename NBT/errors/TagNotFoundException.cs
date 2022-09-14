using System;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    [Serializable]
    internal class TagNotFoundException : Exception
    {
        public TagNotFoundException()
        {
        }

        public TagNotFoundException(string message) : base(message)
        {
        }

        public TagNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TagNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}