using System;

public class Logger
{
    string format = "[{0}:{1}:{2}.{3}] {4}";
    private string Format(string text)
    {
        var now = DateTime.Now;
        return string.Format(format,
            now.Hour.ToString().PadLeft(2, '0'),
            now.Minute.ToString().PadLeft(2, '0'),
            now.Second.ToString().PadLeft(2, '0'),
            now.Millisecond.ToString().PadLeft(3, '0'),
            text);
    }
    public void Write(string text)
    {
        Console.WriteLine(Format(text));
    }
    public void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(Format(text));
        Console.ForegroundColor = ConsoleColor.White;
    }
}