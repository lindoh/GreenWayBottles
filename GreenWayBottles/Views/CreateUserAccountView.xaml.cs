using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class CreateUserAccountView : ContentPage
{

    public CreateUserAccountView()
    {
        InitializeComponent();
        BindingContext = new CreateUserAccViewModel();
    }

}