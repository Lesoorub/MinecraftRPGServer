using Newtonsoft.Json;

public sealed class TextScheme
{
    public string translate;
    public Chat[] with;

    private readonly static JsonSerializerSettings notNull = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore };
    public TextScheme(string translate, Chat[] with)
    {
        this.translate = translate;
        this.with = with;
    }

    public static string JSONScheme(string translate, params Chat[] objs) =>
        new TextScheme(translate, objs).ToString();

    public override string ToString() =>
        JsonConvert.SerializeObject(this, Formatting.None, notNull);
}