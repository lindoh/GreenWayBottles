using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class ResetPasswordView : ContentPage
{
    public ResetPasswordView()
    {
        InitializeComponent();
        BindingContext = new ManagePasswordViewModel();
    }
}