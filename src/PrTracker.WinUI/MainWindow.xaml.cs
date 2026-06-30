using Microsoft.UI.Xaml;

namespace PrTracker.WinUI;

/// <summary>
/// Master/detail main window. Hosts the records list and the edit pane,
/// both bound to <see cref="MainViewModel"/> via compiled <c>x:Bind</c>.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Content = new MainPage();
    }
}
