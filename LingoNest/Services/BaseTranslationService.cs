using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LingoNest.Interfaces;
using LingoNest.Models;

namespace LingoNest.Services;

public abstract class BaseTranslationService : ITranslationService
{
    protected readonly HttpClient Http;

    protected BaseTranslationService()
    {
        Http = new HttpClient();
    }

    protected bool ValidateInput(string text)
    {
        return !string.IsNullOrWhiteSpace(text) && text.Length <= 5000;
    }

    public abstract Task<string> TranslateAsync(string text, string fromLang, string toLang);
    public abstract Task<string> DetectLanguageAsync(string text);
    public abstract IEnumerable<Language> GetSupportedLanguages();
}