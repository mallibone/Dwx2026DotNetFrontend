using Microsoft.Extensions.Logging;
using PrTracker.Core;
using PrTracker.Maui.ViewModels;
using PrTracker.Maui.Views;

namespace PrTracker.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Shared domain service + view-models + pages.
		builder.Services.AddSingleton<IRecordService, InMemoryRecordService>();
		builder.Services.AddSingleton<RecordsViewModel>();
		builder.Services.AddSingleton<RecordsPage>();
		builder.Services.AddTransient<RecordEditViewModel>();
		builder.Services.AddTransient<RecordEditPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if DEVFLOW
		// dotnet/maui-labs DevFlow agent: lets an AI agent read the live visual tree.
		// Enabled via -p:EnableDevFlow=true (Debug only). See README "DevFlow".
		builder.AddMauiDevFlowAgent();
#endif

		return builder.Build();
	}
}
