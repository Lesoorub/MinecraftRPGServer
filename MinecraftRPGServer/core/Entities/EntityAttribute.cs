using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class EntityAttribute : Attribute
{
    public string nameid;
    public CustomCommandNode customCmd;
    public EntityAttribute(string nameid)
    {
        this.nameid = nameid;
    }
    public EntityAttribute(string nameid, Type customCmd)
    {
        this.nameid = nameid;
        this.customCmd = Activator.CreateInstance(customCmd) as CustomCommandNode;
    }
}
