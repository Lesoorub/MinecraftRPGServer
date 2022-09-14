using System;

public class Logger
{
    string format = "[{0}:{1}:{2}.{3}] {4}";
    public void WriteLine(string text)
    {
        var now = DateTime.Now;
        text = string.Format(format, 
            now.Hour.ToString().PadLeft(2, '0'), 
            now.Minute.ToString().PadLeft(2, '0'), 
            now.Second.ToString().PadLeft(2, '0'),
            now.Millisecond.ToString().PadLeft(3, '0'), 
            text);
        Console.WriteLine(text);
    }
}