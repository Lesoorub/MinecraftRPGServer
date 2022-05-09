using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Time
{
    public static long Now() => new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
}