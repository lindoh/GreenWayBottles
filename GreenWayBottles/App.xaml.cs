using GreenWayBottles.ViewModels;
using GreenWayBottles.Views;
using GreenWayBottles.Models;

namespace GreenWayBottles;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		viewModel = new LoginViewModel();

		if (!viewModel.UserLogin.IsLoggedIn)
			MainPage = new LoginView();
		else
			MainPage = new AppShell();
	}

	LoginViewModel viewModel;

	
}
