using GreenWayBottles.Views;

namespace GreenWayBottles;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(RegistrationView), typeof(RegistrationView));
	}
}
