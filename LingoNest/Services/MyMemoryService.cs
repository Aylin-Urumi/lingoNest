using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LingoNest.Models;
using Newtonsoft.Json.Linq;

namespace LingoNest.Services;

public class MyMemoryService : BaseTranslationService
{
    private const string BaseUrl = "https://api.mymemory.translated.net/get";

    public override async Task<string> TranslateAsync(string text, string fromLang, string toLang)
    {
        if (!ValidateInput(text)) return "Invalid input.";

        string url = $"{BaseUrl}?q={Uri.EscapeDataString(text)}&langpair={fromLang}|{toLang}";
        string response = await Http.GetStringAsync(url);

        JObject json = JObject.Parse(response);
        return json["responseData"]?["translatedText"]?.ToString() ?? "Translation failed.";
    }

    public override async Task<string> DetectLanguageAsync(string text)
    {
        // MyMemory doesn't support detection, return unknown
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