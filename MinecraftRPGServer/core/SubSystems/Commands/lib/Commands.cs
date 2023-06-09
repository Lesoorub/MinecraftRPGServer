using System;
using System.Collections.Generic;
using System.Linq;
using MineServer;
public static class Commands
{
    public static Command root = new Command(new Node(), null);
    public static byte[] DeclareCommands;
    public delegate void ExecuteArgs(MinecraftCore server, Player player, string[] args);
    
    static Commands()
    {
        Init();
    }
    public static void Init()
    {
        foreach (var cmd_type in Tools.GetAllTypesWithAttribute<ChatCommandAttribute>())
        {
            var obj = Activator.CreateInstance(cmd_type) as IChatCommand;
            obj.Register();
        }
        DeclareCommands = GetDecloration();
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
        parent.node.Childrens.Add(node);
        return cmd;
    }
    public static bool Execute(string cmd, MinecraftCore server, Player player, string[] args)
    {
        var spl = cmd.TrimStart('/').Split(' ');
        Command current = root;
        for (int k = 0; k < spl.Length; k++)
        {
            current = current.childrens.Find(x => x.node.Name == spl[k]);

            if (current == null) return false;
        }
        current.Action.Invoke(server, player, args);
        return true;
    }
    public static byte[] GetDecloration()
    {
        var nodes = new List<Node>(10);

        void AddNodes(Node node)
        {
            if (node.Flags.HasFlag(Node.FlagsEnum.HasRedirect))
                AddNodes(node.RedirectNode);
            foreach (var n in node.Childrens)
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