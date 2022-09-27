using GreenWayBottles.Views;

namespace GreenWayBottles;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(RegistrationView), typeof(RegistrationView));
		Routing.RegisterRoute(nameof(CreateLoginsView), typeof(CreateLoginsView));
		Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
	}
}
