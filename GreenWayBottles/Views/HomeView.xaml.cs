using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class HomeView : ContentPage
{
    public HomeView()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();

    }
}