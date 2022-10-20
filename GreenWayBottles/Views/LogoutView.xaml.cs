using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class LogoutView : ContentPage
{
	public LogoutView()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}