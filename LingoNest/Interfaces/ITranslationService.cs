using System.Collections.Generic;
using System.Threading.Tasks;
using LingoNest.Models;

namespace LingoNest.Interfaces;

public interface ITranslationService
{
    Task<string> TranslateAsync(string text, string fromLang, string toLang);
    Task<string> DetectLanguageAsync(string text);
    IEnumerable<Language> GetSupportedLanguages();
}