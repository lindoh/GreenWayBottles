using System.Data;
using GreenWayBottles.ViewModels;

namespace GreenWayBottles;

public partial class MainPage : Shell
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new CreateUserAccViewModel();
		BindingContext = new UpdateUserAccViewModel();	
		BindingContext = new DeleteUserAccViewModel();	
		BindingContext = new UpdateBankingViewModel();
	}

	
}

