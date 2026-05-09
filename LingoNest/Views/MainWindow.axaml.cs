using Avalonia.Controls;
using LingoNest.ViewModels;

namespace LingoNest.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnTranslateClicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
            await vm.TranslateAsync();
    }
}