using GreenWayBottles.Services;

namespace GreenWayBottles;

public partial class App : Application
{
	public static IServiceProvider Services;
	public static IAlertService AlertSvc;
	public App()
	{
		InitializeComponent();

		

		MainPage = new AppShell();
	}
}
