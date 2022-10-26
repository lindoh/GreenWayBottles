using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class ManagePasswordView : ContentPage
{
	public ManagePasswordView()
	{
		InitializeComponent();
		BindingContext = new ManagePasswordViewModel();
	}
}