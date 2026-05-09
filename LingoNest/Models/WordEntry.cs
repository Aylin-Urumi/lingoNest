using System;

namespace LingoNest.Models;

public class WordEntry
{
    public string Word { get; set; } = "";
    public string SourceLanguage { get; set; } = "";
    public string TargetLanguage { get; set; } = "";
    public string TranslatedText { get; set; } = "";
    public DateTime SavedAt { get; set; } = DateTime.Now;

    public override string ToString() => $"{Word} → {TranslatedText}";
}