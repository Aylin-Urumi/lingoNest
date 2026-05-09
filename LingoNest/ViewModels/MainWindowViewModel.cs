using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LingoNest.Interfaces;
using LingoNest.Models;
using LingoNest.Services;
using ReactiveUI.Fody.Helpers;

namespace LingoNest.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ITranslationService _translationService;

    [Reactive] public string InputText { get; set; } = "";
    [Reactive] public string TranslatedText { get; set; } = "";
    [Reactive] public string StatusMessage { get; set; } = "Ready";
    [Reactive] public bool IsLoading { get; set; } = false;
    [Reactive] public Language? SelectedSourceLanguage { get; set; }
    [Reactive] public Language? SelectedTargetLanguage { get; set; }
    [Reactive] public ObservableCollection<WordEntry> TranslationHistory { get; set; } = new();

    public ObservableCollection<Language> Languages { get; } = new();

    public MainWindowViewModel()
    {
        _translationService = new MyMemoryService();
        LoadLanguages();
    }

    private void LoadLanguages()
    {
        foreach (var lang in _translationService.GetSupportedLanguages())
            Languages.Add(lang);

        SelectedSourceLanguage = Languages.FirstOrDefault(l => l.Code == "en");
        SelectedTargetLanguage = Languages.FirstOrDefault(l => l.Code == "tr");
    }

    public async Task TranslateAsync()
    {
        if (string.IsNullOrWhiteSpace(InputText))
        {
            StatusMessage = "Please enter some text.";
            return;
        }

        if (SelectedSourceLanguage == null || SelectedTargetLanguage == null)
        {
            StatusMessage = "Please select languages.";
            return;
        }

        try
        {
            IsLoading = true;
            StatusMessage = "Translating...";

            string result = await _translationService.TranslateAsync(
                InputText,
                SelectedSourceLanguage.Code,
                SelectedTargetLanguage.Code
            );

            TranslatedText = result;

            TranslationHistory.Insert(0, new WordEntry
            {
                Word = InputText,
                SourceLanguage = SelectedSourceLanguage.Name,
                TargetLanguage = SelectedTargetLanguage.Name,
                TranslatedText = result,
                SavedAt = DateTime.Now
            });

            StatusMessage = "Done!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }
}