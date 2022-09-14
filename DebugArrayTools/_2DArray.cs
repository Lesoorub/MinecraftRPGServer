using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class _2DArray<T>
{
    const char separator = '|';
    T[,] arr;
    public string _ToString
    {
        get
        {
            StringBuilder sb = new StringBuilder();

            int max = 1;

            for (int y = 0; y < arr.GetLength(1); y++)
            {
                for (int x = 0; x < arr.GetLength(0); x++)
                {
                    var t = arr[x, y].ToString().Length;
                    if (max < t)
                        max = t;
                }
            }

            if (arr.GetLength(0).ToString().Length > max)
                max = arr.GetLength(0).ToString().Length;

            sb.Append($"y\\x{new string(' ', Math.Max(0, arr.GetLength(1).ToString().Length - 1))}{separator}");
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                sb.Append(x.ToString().PadLeft(Math.Max(arr.GetLength(0).ToString().Length, max), ' '));
                sb.Append(separator);
            }
            sb.AppendLine();

            for (int y = 0; y < arr.GetLength(1); y++)
            {
                sb.Append($"y={y.ToString().PadLeft(arr.GetLength(1).ToString().Length)}{separator}");
                for (int x = 0; x < arr.GetLength(0); x++)
                {
                    sb.Append(arr[x, y].ToString().PadLeft(max, ' '));
                    if (x + 1 < arr.GetLength(0))
                        sb.Append(separator);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    public _2DArray(T[,] arr)
    {
        this.arr = arr;
    }
    public static implicit operator T[,](_2DArray<T> t) => t.arr;
}
public static class _2DArrayExtensions
{
    public static _2DArray<T> ToDebugArray<T>(this T[,] arr) => new _2DArray<T>(arr);
}