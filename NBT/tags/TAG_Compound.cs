using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Compound : TAG, IList<TAG>
    {
        public const int _TypeID = 10;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public List<TAG> data = new List<TAG>(10);
        public override TAG this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
        public override TAG this[string name]
        {
            get => data.FirstOrDefault(x => x.name.Equals(name));
            set
            {
                if (name == null) return;
                if (value == null)
                {
                    RemoveTag(name);
                    return;
                }
                value.name = name;

                for (int k = 0; k < data.Count; k++)
                    if (data[k].name.Equals(name))
                    {
                        data[k] = value;
                        return;
                    }
                data.Add(value);
            }
        }
        public TAG_Compound(string name = "") : base(name)
        {
            data = new List<TAG>();
        }
        public TAG_Compound(byte[] raw, ref int offset) : base("")
        {
            TAG t;
            while ((t = Read(raw[offset++], raw, ref offset, true)).TypeID != TAG_END._TypeID)
            {
                Add(t);
            }
        }
        public TAG_Compound(List<TAG> body, string name = "") : base(name)
        {
            this.data = body;
        }
        public override void SetDepth(int d)
        {
            base.SetDepth(d);
            foreach (TAG tag in data)
            {
                tag.SetDepth(d + 1);
            }
        }
        public override byte[] Bytes
        {
            get
            {
                var ab = new ArrayOfBytesBuilder();
                foreach (var d in data)
                    if (d is TAG tag)
                        ab.Append(tag.NamedBytes);
                ab.Append(new TAG_END().Bytes);
                return ab.ToArray();
            }
        }
        public static implicit operator List<TAG>(TAG_Compound tag) => tag.data;
        public static implicit operator NBTTag(TAG_Compound tag) => new NBTTag(tag);
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string d = new string(' ', depth);
            sb.AppendLine($"TAG_Compound({namelen}'{name}'): ");
            sb.AppendLine(d + "{");

            foreach (var x in data)
            {
                sb.AppendLine(d + " " + x.ToString());
            }

            sb.Append(d + "}");
            return sb.ToString();

        }
        public bool HasTag(string name) => data.Any(x => x.name.Equals(name));
        public TAG_Compound RemoveTag(string name)
        {
            int index = data.FindIndex(x => x.name.Equals(name));
            if (index == -1) return this;
            data.RemoveAt(index);
            return this;
        }
        public TAG_Compound RemoveTags(string[] names)
        {
            data.RemoveAll(x => names.Contains(x.name));
            return this;
        }
        public override bool Equals(TAG tag)
        {
            if (tag is TAG_Compound t &&
                data.Count == t.data.Count)
            {
                for (int k = 0; k < data.Count; k++)
                {
                    if (!Equals(data[k], t.data[k]))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override dynamic ToDynamic()
        {
            dynamic obj = new ExpandoObject();
            var d = (ICollection<KeyValuePair<string, dynamic>>)obj;
            foreach (var pair in data)
                d.Add(new KeyValuePair<string, dynamic>(pair.name, pair.ToDynamic()));
            return obj;
        }
        public override string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Join(
                ",",
                data.Select(
                    pair => $"\"{pair.name}\":{pair.ToJson()}")));
            sb.Append("}");
            return sb.ToString();
        }
        #region listinterface
        public int Count => ((ICollection<TAG>)data).Count;

        public bool IsReadOnly => ((ICollection<TAG>)data).IsReadOnly;
        public int IndexOf(TAG item)
        {
            return ((IList<TAG>)data).IndexOf(item);
        }

        public void Insert(int index, TAG item)
        {
            ((IList<TAG>)data).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<TAG>)data).RemoveAt(index);
        }

        public void Add(TAG item)
        {
            ((ICollection<TAG>)data).Add(item);
        }

        public void Clear()
        {
            ((ICollection<TAG>)data).Clear();
        }

        public bool Contains(TAG item)
        {
            return ((ICollection<TAG>)data).Contains(item);
        }

        public void CopyTo(TAG[] array, int arrayIndex)
        {
            ((ICollection<TAG>)data).CopyTo(array, arrayIndex);
        }

        public bool Remove(TAG item)
        {
            return ((ICollection<TAG>)data).Remove(item);
        }

        public IEnumerator<TAG> GetEnumerator()
        {
            return ((IEnumerable<TAG>)data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)data).GetEnumerator();
        }

        #endregion listinterface
    }
}