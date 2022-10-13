using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }



}