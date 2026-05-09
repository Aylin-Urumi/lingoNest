using System.Collections.Generic;
using System.Threading.Tasks;
using LingoNest.Models;

namespace LingoNest.Services;

public class MockTranslationService : BaseTranslationService
{
    private readonly Dictionary<string, string> _mockData = new()
    {
        { "hello", "Merhaba" },
        { "goodbye", "Güle güle" },
        { "thank you", "Teşekkür ederim" },
        { "yes", "Evet" },
        { "no", "Hayır" },
        { "water", "Su" },
        { "food", "Yemek" },
        { "help", "Yardım" },
    };

    public override Task<string> TranslateAsync(string text, string fromLang, string toLang)
    {
        string key = text.ToLower().Trim();
        if (_mockData.TryGetValue(key, out string? result))
            return Task.FromResult(result);

        return Task.FromResult($"[Mock] {text} → ({toLang})");
    }

    public override Task<string> DetectLanguageAsync(string text)
    {
        return Task.FromResult("en");
    }

    public override IEnumerable<Language> GetSupportedLanguages()
    {
        return new List<Language>
        {
            new Language { Code = "en", Name = "English" },
            new Language { Code = "tr", Name = "Turkish" },
        };
    }
}