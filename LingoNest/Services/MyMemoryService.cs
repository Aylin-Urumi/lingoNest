using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LingoNest.Models;
using Newtonsoft.Json.Linq;

namespace LingoNest.Services;

public class MyMemoryService : BaseTranslationService
{
    private const string BaseUrl = "https://translate.googleapis.com/translate_a/single";

    public override async Task<string> TranslateAsync(string text, string fromLang, string toLang)
    {
        if (!ValidateInput(text)) return "Invalid input.";

        string url = $"{BaseUrl}?client=gtx&sl={fromLang}&tl={toLang}&dt=t&q={Uri.EscapeDataString(text)}";
        string response = await Http.GetStringAsync(url);

        JArray json = JArray.Parse(response);
        string result = "";

        var sentences = json[0] as JArray;
        if (sentences != null)
            foreach (var sentence in sentences)
                result += sentence[0]?.ToString();

        return string.IsNullOrEmpty(result) ? "Translation failed." : result;
    }

    public override async Task<string> DetectLanguageAsync(string text)
    {
        return await Task.FromResult("unknown");
    }

    public override IEnumerable<Language> GetSupportedLanguages()
    {
        return new List<Language>
        {
            new Language { Code = "en", Name = "English" },
            new Language { Code = "tr", Name = "Turkish" },
            new Language { Code = "fa", Name = "Persian" },
            new Language { Code = "fr", Name = "French" },
            new Language { Code = "de", Name = "German" },
            new Language { Code = "es", Name = "Spanish" },
            new Language { Code = "it", Name = "Italian" },
            new Language { Code = "ar", Name = "Arabic" },
            new Language { Code = "ru", Name = "Russian" },
            new Language { Code = "zh", Name = "Chinese" },
            new Language { Code = "ja", Name = "Japanese" },
        };
    }
}