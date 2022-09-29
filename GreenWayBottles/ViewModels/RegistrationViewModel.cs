
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Views;
using GreenWayBottles.Models;
using GreenWayBottles.Services;


namespace GreenWayBottles.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        public RegistrationViewModel()
        {
            dataService = new DatabaseService();
            user = new Users();
            alerts = new AlertService();
        }

        #region Class Members
        DatabaseService dataService;

        [ObservableProperty]
        private Users user;

        [ObservableProperty]
        Login userLogins;

        private string idNumber;

        [ObservableProperty]
        string confirmPassword;

        AlertService alerts;

        #endregion

        #region ViewModel Buttons
        /// <summary>
        /// The Save Method calls databaseService method to
        /// Save the user data in the database
        /// </summary>
        [RelayCommand]
        async void Register()
        {
            if (user.IdNumber == null || user.IdNumber.Length != 13)
            {
                await alerts.ShowAlertAsync("Registration Operation Failed", "Id Number must be 13 digits long");
            }
            else if (CheckTextFields(user))
            {
                dataService.SaveAdminData(user);
                await alerts.ShowAlertAsync("Success", "User Account Created Successfully");

                //Save the user's Id number before class properties are cleared 
                idNumber = user.IdNumber;

                Clear(User);    //Clear text fields

                //Navigate to the Create Login Details Page
                await Shell.Current.GoToAsync(nameof(CreateLoginsView));
            }
            else
            {
                await alerts.ShowAlertAsync("Operation Failed", "One or more empty text fields found");
            }
        }

        [RelayCommand]
        async void GoToLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }

        [RelayCommand]
        async void PrevBtn()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async void Continue()
        {
            CreateUserLogins();
            await Shell.Current.GoToAsync(nameof(LoginView));
        }
        #endregion

        #region Helper Methods

        public async void CreateUserLogins()
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
                }
                else
                    await alerts.ShowAlertAsync("Operation Failed", "One or more empty fields found");
            }
        }

        /// <summary>
        /// Check if any text fields are empty
        /// </summary>
        /// <returns>Return false if empty else return True</returns>
        private bool CheckTextFields(Users user)
        {
            bool emptyFields = false;

            if (!(user.FirstName == "" || user.LastName == "" || user.IdNumber == "" ||
                user.Gender == "" || user.HighestQlfn == "" || user.IncomeRange == "" ||
                user.Email == "" || user.CellNumber == "" || user.StreetAddress == "" ||
                user.Suburb == "" || user.City == "" || user.Province == "" || user.Country == ""))
            {
                emptyFields = true;

            }

            return emptyFields;
        }

        /// <summary>
        /// Clear all text fields
        /// </summary>
        public void Clear(Users user)
        {
            user.FirstName = "";
            user.LastName = "";
            user.IdNumber = "";
            user.Gender = "";
            user.HighestQlfn = "";
            user.IncomeRange = "";
            user.Email = "";
            user.CellNumber = "";
            user.StreetAddress = "";
            user.Suburb = "";
            user.City = "";
            user.Province = "";
            user.Country = "";
        }

        #endregion
    }
}
