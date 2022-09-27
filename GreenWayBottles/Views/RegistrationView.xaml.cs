using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class RegistrationView : ContentPage
{
	public RegistrationView()
	{
		InitializeComponent();
		BindingContext = new RegistrationViewModel();
	}
}