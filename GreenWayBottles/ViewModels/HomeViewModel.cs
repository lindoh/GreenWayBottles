using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Views;

namespace GreenWayBottles.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public HomeViewModel()
        {
            loginVM = new LoginViewModel();
        }

        [ObservableProperty]
        LoginViewModel loginVM;

        [RelayCommand]
        async void Register()
        {
            await Shell.Current.GoToAsync(nameof(RegistrationView));
        }

        [RelayCommand]
        async void Login()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }
    }
}
