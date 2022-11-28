using GreenWayBottles.ViewModels;
using GreenWayBottles.Views;

/*======================================TO DO========================================
 => Send email reports using Azure server service
 => Unit Testing
 => Publish App
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
