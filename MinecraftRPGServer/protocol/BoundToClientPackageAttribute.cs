[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class BoundToClientPackageAttribute : System.Attribute
{
    public State state;
    public BoundToClientPackageAttribute(State state = State.Play)
    {
        this.state = state;
    }
}