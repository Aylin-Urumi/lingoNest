namespace LingoNest.Models;

public class Language
{
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";

    public override string ToString() => Name;
}