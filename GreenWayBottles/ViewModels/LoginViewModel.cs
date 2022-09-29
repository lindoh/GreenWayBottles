using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using GreenWayBottles.Views;


namespace GreenWayBottles.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {
            dataService = new DatabaseService();
            alerts = new AlertService();
            IsBBCUpdated = false;
            userLogin = new Login();
            UserLogin.IsLoggedIn = false;
        }

        DatabaseService dataService;
        AlertService alerts;

        [ObservableProperty]
        Login userLogin;

        [ObservableProperty]
        BuyBackCentre buyBackCentre;

        [ObservableProperty]
        bool isBBCUpdated;

        #region Class Buttons

        [RelayCommand]
        public async void Login()
        {
            Login currentUser = new Login();

            //Check if text field are empty first
            if (!CheckFields())
            {
                currentUser = dataService.SearchLogins(userLogin);

                if (currentUser.IsLoggedIn)
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

                UserLogin = currentUser;
            }
            else
                await alerts.ShowAlertAsync("Operation Failed", "Username and/or Password text fields are empty");

            

          
        }

        [RelayCommand]
        async void GoToRegistration()
        {
            await Shell.Current.GoToAsync(nameof(RegistrationView));
        }

        [RelayCommand]
        async void PrevBtn()
        {
            await Shell.Current.GoToAsync("..");
        }
        #endregion

        #region Helper Methods
        private bool CheckFields()
        {
            if(userLogin.Username == "" && userLogin.Password == "")
                return true;
            else
                return false;

        }

        #endregion
    }
}
