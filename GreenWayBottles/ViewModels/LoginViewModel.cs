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
            mainPage = new MainPageViewModel();
            userLogin = new Login();
            MainPage.IsBBCUpdated = true;
            MainPage.IsLoggedIn = true;
        }

        DatabaseService dataService;
        AlertService alerts;

        [ObservableProperty]
        Login userLogin;

        [ObservableProperty]
        BuyBackCentre buyBackCentre;

        [ObservableProperty]
        MainPageViewModel mainPage;

        #region Class Buttons

        [RelayCommand]
        async void Login()
        {
            Login currentUser;

            //Check if text field are empty first
            if (!CheckFields())
            {
                currentUser = dataService.SearchLogins(userLogin);

                if (currentUser.IsLoggedIn)
                {
                    MainPage.IsLoggedIn = true; 

                    await alerts.ShowAlertAsync("Access Granted", "The user has succesfully Logged In");

                    buyBackCentre = dataService.SearchBBC(currentUser.AdminId);

                    if (buyBackCentre.BBCId != 0)
                    {
                        currentUser.BBCId = buyBackCentre.BBCId;
                        MainPage.IsBBCUpdated = true;
                        
                    }
                    else
                        await alerts.ShowAlertAsync("Missing Information Detected", "The user is required to Update BuyBackCentre Details under Update User Account Tab and ReLogin");

                    //Navigate to the Home Page
                    await Shell.Current.GoToAsync($"{"///MainPage"}?IsBBCUpdated={MainPage.IsBBCUpdated}");
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
        async void HomeBtn()
        {
            await Shell.Current.GoToAsync("../");
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
