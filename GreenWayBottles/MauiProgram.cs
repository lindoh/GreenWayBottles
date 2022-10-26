namespace GreenWayBottles;
using CommunityToolkit.Maui;
using GreenWayBottles.Services;
using GreenWayBottles.ViewModels;
using GreenWayBottles.Views;
using CommunityToolkit.Maui.Markup;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

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
        builder.Services.AddTransient<LogoutView>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddSingleton<ManagePasswordView>();
        builder.Services.AddSingleton<ManagePasswordViewModel>();

        builder.Services.AddSingleton<IAlertService, AlertService>();

        return builder.Build();
    }
}
