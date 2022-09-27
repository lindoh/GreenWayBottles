using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Views;

namespace GreenWayBottles.ViewModels
{
    public partial class HomeViewModel 
    {
        public HomeViewModel()
        {

        }

        [RelayCommand]
        async void Register()
        {
            await Shell.Current.GoToAsync(nameof(RegistrationView));
        }

        async void Login()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }
    }
}
