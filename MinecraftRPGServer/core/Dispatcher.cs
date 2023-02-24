using System;
using System.Collections.Generic;

public class Dispatcher
{
    Queue<Action> actions = new Queue<Action>();
    public void DispatchAll()
    {
        lock (actions)
        {
            while (actions.Count > 0)
                actions.Dequeue()();
        }
    }

    public void Invoke(Action action)
    {
        lock (actions)
            actions.Enqueue(action);
    }
}