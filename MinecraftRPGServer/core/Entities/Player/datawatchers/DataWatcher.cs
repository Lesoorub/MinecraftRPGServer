public abstract class DataWatcher<T>
{
    public delegate void ChangeArgs(object obj, T args);
    public event ChangeArgs OnChange;

    protected void InvokeOnChange(object obj, T args) =>
        OnChange?.Invoke(obj, args);

    public virtual void Update() { }
}
