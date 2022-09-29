using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class CreateLoginsView : ContentPage
{
	public CreateLoginsView()
	{
		InitializeComponent();
		BindingContext = new RegistrationViewModel();
	}
}