public static class MotdDescriptionCreator
{
    public const int line_width = 63;
    public static string PadBoth(string source, char fillchar)
    {
        int spaces = line_width - source.Length;
        int padLeft = spaces / 2 + source.Length / 2;
        return source.PadLeft(padLeft, fillchar).PadRight(line_width, fillchar);

    }
    public static string Description(string firstLine, string secondLine)
    {
        return firstLine.PadLeft(line_width, ' ') + " " + secondLine;
    }
}