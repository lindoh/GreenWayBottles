using GreenWayBottles.ViewModels;
using System.Data;

namespace GreenWayBottles;

public partial class MainPage : Shell
{
	CreateUserAccViewModel createUserAccViewModel;
	public MainPage()
	{
		InitializeComponent();
		createUserAccViewModel = new CreateUserAccViewModel();
		
	}

	
}

