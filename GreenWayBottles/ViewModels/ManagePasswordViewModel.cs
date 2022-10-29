using CommunityToolkit.Mvvm.ComponentModel;
using GreenWayBottles.Services;
using GreenWayBottles.Models;
using GreenWayBottles.ViewModels;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Views;

namespace GreenWayBottles.ViewModels
{
    public partial class ManagePasswordViewModel : ObservableObject
    {
        public ManagePasswordViewModel()
        {
            dataService = new DatabaseService();
            alerts = new AlertService();
            createLoginsVM = new CreateLoginsViewModel();
            login = new LoginViewModel();
        }

        [ObservableProperty]
        string oldPassword;

        [ObservableProperty]
        string newPassword;

        [ObservableProperty]
        string confirmPassword;

        DatabaseService dataService;

        AlertService alerts;

        [ObservableProperty]
        LoginViewModel login;

        CreateLoginsViewModel createLoginsVM;

        [RelayCommand]
        async void Update()
        {
            //Confirm Old Password
            if (Login.UserLogin.IsLoggedIn)
            {
                if (oldPassword == null || NewPassword == null || confirmPassword == null)
                {
                    await alerts.ShowAlertAsync("Operation Failed", "One or more empty fields found");
                    return;
                }

                if (login.UserLogin.Password != oldPassword)
                {
                    await alerts.ShowAlertAsync("Operation Failed", "The provided Old Password is invalid!");
                    return;
                }

                if (newPassword == oldPassword)
                {
                    await alerts.ShowAlertAsync("Operation Failed", "Your new password cannot be similar to your old password");
                    return;
                }

                //Validate password
                if (!createLoginsVM.ValidatePassword(NewPassword))
                    await alerts.ShowAlertAsync("Invalid Password", "Please check Password Guidlines Highlighted in red below!");
                else if (!(NewPassword == confirmPassword))
                    await alerts.ShowAlertAsync("Operation Failed", "Passwords do not match");
                else
                {
                    bool isUpdated = dataService.UpdatePassword(login.UserLogin.AdminId, newPassword);

                    if (isUpdated)
                    {
                        await alerts.ShowAlertAsync("Operation Successful", "Login Details Saved Successfully");
                        //Navigate to the Home Page
                        //App.Current.MainPage = new AppShell();
                        //await Shell.Current.GoToAsync(nameof(LoginView));
                    }
                    else
                        await alerts.ShowAlertAsync("Operation Failed", "The password could not be updated!");
                }
            }

            Clear();
        }

        /// <summary>
        /// Clear Text Fields
        /// </summary>
        private void Clear()
        {
            Login.UserLogin.Username = "";
            Login.UserLogin.Password = "";
        }

    }
}
