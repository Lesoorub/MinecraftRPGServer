public delegate void ExecuteArgs(Entity ent, string[] args); 
public abstract class CustomCommandNode
{
    public virtual Node node { get; }
    public virtual ExecuteArgs onExecute { get; }
}