[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class BoundToServerPackageAttribute : System.Attribute
{
    public State state;
    public BoundToServerPackageAttribute(State state = State.Play)
    {
        this.state = state;
    }
}
