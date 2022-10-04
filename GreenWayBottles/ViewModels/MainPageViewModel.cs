using CommunityToolkit.Mvvm.ComponentModel;
using GreenWayBottles.Models;

namespace GreenWayBottles.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            loginVM = new LoginViewModel();
        }

        [ObservableProperty]
        LoginViewModel loginVM;
    }
}
