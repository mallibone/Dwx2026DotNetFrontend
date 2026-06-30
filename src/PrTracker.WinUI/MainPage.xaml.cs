using Microsoft.UI.Xaml.Controls;

namespace PrTracker.WinUI;

/// <summary>
/// Master/detail page. Hosts the records list and the edit pane,
/// both bound to <see cref="MainViewModel"/> via compiled <c>x:Bind</c>.
/// </summary>
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    public MainViewModel ViewModel { get; } = new();
}
