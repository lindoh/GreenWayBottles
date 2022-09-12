namespace GreenWayBottles;
using GreenWayBottles.ViewModels;
using GreenWayBottles.Services;

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

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<CreateUserAccViewModel>();
		builder.Services.AddSingleton<UpdateUserAccViewModel>();
		builder.Services.AddSingleton<DeleteUserAccViewModel>();
		builder.Services.AddSingleton<UpdateBankingViewModel>();

		builder.Services.AddSingleton<IAlertService, AlertService>();

		return builder.Build();
	}
}
