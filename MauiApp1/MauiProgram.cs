using Microsoft.Extensions.Logging;
using MauiApp1.Services;
using MauiApp1.Helpers;
using MauiApp1.PlatformsShared;
using System.Net.Http;

namespace MauiApp1;

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
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSingleton<IParserSerivce, ParserSerivce>();
		builder.Services.AddSingleton<IToaster>((e)=> new Toaster());
		builder.Services.AddSingleton<IConnectivity>((e) => Connectivity.Current);
#if __ANDROID__
		builder.Services.AddSingleton<IIntentHandler>((e)=>new VlcPlayerIntent());
#endif

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
