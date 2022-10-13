using GreenWayBottles.ViewModels;
using GreenWayBottles.Views;
/* Unmerged change from project 'GreenWayBottles (net6.0-ios)'
Before:
using GreenWayBottles.Models;
After:
using GreenWayBottles.Views;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-maccatalyst)'
Before:
using GreenWayBottles.Models;
After:
using GreenWayBottles.Views;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-windows10.0.19041.0)'
Before:
using GreenWayBottles.Models;
After:
using GreenWayBottles.Views;
*/


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
