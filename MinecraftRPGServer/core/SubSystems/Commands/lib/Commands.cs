using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using MineServer;
public static class Commands
{
    public static Command root = new Command(new Node(), null);
    public static byte[] DeclareCommands;
    public delegate void ExecuteArgs(Player player, string[] args);
    public static void Init()
    {
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();
        foreach (var cmd_type in RPGServer.GetTypesWithAttribute<ChatCommandAttribute>())
        {
            var obj = Activator.CreateInstance(cmd_type) as IChatCommand;
            obj.Register();
        }
        DeclareCommands = GetDecloration();
        timer.Stop();
        Console.WriteLine($"Commands loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
    public static Command Register(string cmd, ExecuteArgs action)
    {
        if (cmd.Contains(' ')) throw new Exception("Command can't contains ' ' symbols");
        return Register(
            new Node()
            {
                Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable,
                Name = cmd,
            },
            action);
    }
    public static Command Register(Node node, ExecuteArgs action) =>
        Register(root, node, action);
    public static Command Register(Command parent, Node node, ExecuteArgs action)
    {
        Command cmd = new Command(node, action);
        //if (!node.Flags.HasFlag(Node.FlagsEnum.IsExecutable))
        //    node.Flags |= Node.FlagsEnum.IsExecutable;
        parent.childrens.Add(cmd);
        parent.node.Children.Add(node);
        return cmd;
    }
    public static bool Execute(string cmd, Player player, string[] args)
    {
        var spl = cmd.TrimStart('/').Split(' ');
        Command current = root;
        for (int k = 0; k < spl.Length; k++)
        {
            current = current.childrens.Find(x => x.node.Name == spl[k]);

            if (current == null) return false;
        }
        current.Action.Invoke(player, args);
        return true;
    }
    public static byte[] GetDecloration()
    {
        var nodes = new List<Node>(10);

        void AddNodes(Node node)
        {
            if (node.Flags.HasFlag(Node.FlagsEnum.HasRedirect))
                AddNodes(node.RedirectNode);
            foreach (var n in node.Children)
                AddNodes(n);
            nodes.Add(node);
        }

        AddNodes(root.node);

        for (int k = 0; k < nodes.Count; k++)
            nodes[k].index = k;

        var writer = new ArrayWriter(true);
        writer.Write(nodes.ToArray());
        writer.Write(new VarInt(root.node.index));
        return writer.ToArray();
    }
    public class Command
    {
        public Command(Node node, ExecuteArgs Action)
        {
            this.node = node;
            this.Action = Action;
        }
        public List<Command> childrens = new List<Command>();
        public Node node;
        public ExecuteArgs Action;
    }
}
/*

/home (name:string)
/home add (name:string)
/home remove (name:string)
/home list

*/