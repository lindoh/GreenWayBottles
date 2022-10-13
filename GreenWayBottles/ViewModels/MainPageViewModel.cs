using CommunityToolkit.Mvvm.ComponentModel;

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
