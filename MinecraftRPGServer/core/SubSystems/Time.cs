using System;

public static class Time
{
    public static long Now() => new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
}