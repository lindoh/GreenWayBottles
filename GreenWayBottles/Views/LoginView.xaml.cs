using GreenWayBottles.ViewModels;
using SignaturePad.Forms;

namespace GreenWayBottles.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }



}