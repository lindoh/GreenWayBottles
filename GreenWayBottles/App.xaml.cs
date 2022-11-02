using GreenWayBottles.ViewModels;
using GreenWayBottles.Views;

/*======================================TO DO========================================
 => Send email reports using Azure server service
 => Keyboard enter button
 => Add SAB Bottles
 => Unit Testing
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
