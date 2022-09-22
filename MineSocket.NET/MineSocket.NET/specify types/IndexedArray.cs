using System.Collections.Generic;
using System.Linq;

namespace MineServer
{
    public class IndexedArray<T> : SerializableToBytes
    {
        public List<T> pallete = new List<T>();
        public VarInt[] indexes;

        public T this[int index]
        {
            get => pallete[indexes[index]];
            set => Set(value, index);
        }

        public IndexedArray(uint length)
        {
            indexes = new VarInt[length];
        }
        public IndexedArray(uint length, IEnumerable<T> data) : this(length)
        {
            for (int k = 0; k < data.Count(); k++)
                Set(data.ElementAt(k), k);
        }
        void Set(T item, int index)
        {
            int pos = pallete.IndexOf(item);
            if (pos == -1)
            {
                pos = pallete.Count;
                pallete.Add(item);
            }
            indexes[index] = pos;
        }
    }
}