using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Time
{
    public static long GetTime() => new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
}