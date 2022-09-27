using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using GreenWayBottles.ViewModels;

namespace GreenWayBottles.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {
            dataService = new DatabaseService();
            alerts = new AlertService();
            IsBBCUpdated = false;
        }

        DatabaseService dataService;
        AlertService alerts;

        [ObservableProperty]
        Login currentUser;

        [ObservableProperty]
        BuyBackCentre buyBackCentre;

        [ObservableProperty]
        bool isBBCUpdated;

        [RelayCommand]
        public async void Login()
        {
            CurrentUser = dataService.SearchLogins(currentUser);

            if(currentUser.IsLoggedIn)
            {
                await alerts.ShowAlertAsync("Login Successfully", "The user has succesfully Logged In");

                buyBackCentre = dataService.SearchBBC(currentUser.AdminId);

                if (buyBackCentre.BBCId != 0)
                {
                    currentUser.BBCId = buyBackCentre.BBCId;
                    IsBBCUpdated = true;
                }
                else
                    await alerts.ShowAlertAsync("Missing Information Detected", "The user is required to Update BuyBackCentre Details under Update User Account Tab and ReLogin");
            }
            else
            {
                await alerts.ShowAlertAsync("Login Failed", "The user could not be found, Register a new account instead");
            }
        }
    }
}
