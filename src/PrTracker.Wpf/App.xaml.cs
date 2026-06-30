using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PrTracker.Core;
using PrTracker.Wpf.ViewModels;

namespace PrTracker.Wpf;

/// <summary>
/// Application entry point. Builds a small DI container, then resolves and
/// shows the main window on startup.
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _services;

    public App()
    {
        var services = new ServiceCollection();

        // Domain services (shared across every UI in the repo).
        services.AddSingleton<IRecordService, InMemoryRecordService>();

        // View-models.
        services.AddTransient<RecordsViewModel>();
        services.AddTransient<RecordEditViewModel>();

        // Views.
        services.AddTransient<MainWindow>();

        _services = services.BuildServiceProvider();
    }

    /// <summary>Exposes the container so views can resolve dependencies (e.g. the edit window).</summary>
    public IServiceProvider Services => _services;

    /// <summary>Convenience accessor for the running app instance.</summary>
    public static new App Current => (App)Application.Current;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = _services.GetRequiredService<MainWindow>();
        window.Show();
    }
}
