namespace GreenWayBottles;
using GreenWayBottles.ViewModels;
using GreenWayBottles.Services;
using GreenWayBottles.Views;

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
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<CreateUserAccountView>();
		builder.Services.AddSingleton<CreateUserAccViewModel>();

		builder.Services.AddSingleton<UpdateUserAccountView>();	
		builder.Services.AddSingleton<UpdateUserAccViewModel>();

		builder.Services.AddSingleton<DeleteUserAccView>();
		builder.Services.AddSingleton<DeleteUserAccViewModel>();

		builder.Services.AddSingleton<UpdateBankingView>();
		builder.Services.AddSingleton<UpdateBankingViewModel>();

		builder.Services.AddSingleton<CaptureNewBottlesView>();
		builder.Services.AddSingleton<CaptureBottlesViewModel>();

		builder.Services.AddTransient<RegistrationView>();
		builder.Services.AddTransient<CreateLoginsView>();
		builder.Services.AddTransient<RegistrationViewModel>();

		builder.Services.AddTransient<LoginView>();
		builder.Services.AddTransient<LoginViewModel>();

		builder.Services.AddSingleton<IAlertService, AlertService>();

		return builder.Build();
	}
}
