using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using GreenWayBottles.Views;

namespace GreenWayBottles.ViewModels
{
    public partial class CreateLoginsViewModel : ObservableObject
    {
        public CreateLoginsViewModel()
        {
            userLogins = new Login();
            dataService = new DatabaseService();
            alerts = new AlertService();
            confirmPassword = "";
        }

        [ObservableProperty]
        Login userLogins;

        [ObservableProperty]
        static string idNumber;

        [ObservableProperty]
        public string confirmPassword;

        DatabaseService dataService;

        AlertService alerts;


        [RelayCommand]
        async void Continue()
        {
            int adminId = dataService.SearchAdmin(idNumber);

            if (!(UserLogins.Password == confirmPassword))
                await alerts.ShowAlertAsync("Operation Failed", "Passwords do not match");
            else if (!(UserLogins.Username == "" && UserLogins.Password == "" && confirmPassword == ""))
            {
                UserLogins.AdminId = adminId;
                bool isSaved = dataService.SaveLogins(userLogins);

                if (isSaved)
                {
                    await alerts.ShowAlertAsync("Operation Successful", "Login Details Saved Successfully");
                    await Shell.Current.GoToAsync(nameof(LoginView));
                }
                else
                    await alerts.ShowAlertAsync("Operation Failed", "One or more empty fields found");
            }

        }
    }
}
