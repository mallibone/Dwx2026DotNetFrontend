using PrTracker.Maui.Views;

namespace PrTracker.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Detail route for push navigation (add / edit).
        Routing.RegisterRoute(nameof(RecordEditPage), typeof(RecordEditPage));
    }
}
