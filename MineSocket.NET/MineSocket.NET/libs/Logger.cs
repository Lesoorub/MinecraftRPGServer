using System;
using System.Collections.Generic;

namespace MineServer
{
    public class Logger
    {
        public delegate void MessageArgs(string msg);
        public event MessageArgs OnMessage;

        public List<string> buffer = new List<string>();
        public string format = "[{0}:{1}:{2}:{3} {4}] {5}";

        public void Write(string msg, string type = "LOG")
        {
            DateTime now = DateTime.Now;
            string t = string.Format(format, now.Hour, now.Minute, now.Second, now.Millisecond.ToString().PadLeft(4, '0'), "LOG", msg);
            buffer.Add(t);
            OnMessage?.Invoke(t);
        }
        public override string ToString()
        {
            string sum = "";
            foreach (var x in buffer)
                sum += x;
            return sum;
        }
    }
}