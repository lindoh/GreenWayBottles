
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Views;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using GreenWayBottles.ViewModels;


namespace GreenWayBottles.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        #region Default Constructor
        public RegistrationViewModel()
        {
            dataService = new DatabaseService();
            user = new Users();
            alerts = new AlertService();
            logins = new CreateLoginsViewModel();
        }

        #endregion

        #region Class Members
        DatabaseService dataService;

        [ObservableProperty]
        private Users user;

        [ObservableProperty]
        Login userLogins;

        [ObservableProperty]
        CreateLoginsViewModel logins;


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
                Logins.IdNumber = user.IdNumber;

                Clear(User);    //Clear text fields

                //Navigate to the Create Login Details Page
                await Shell.Current.GoToAsync(nameof(CreateLoginsView));
            }
            else
            {
                await alerts.ShowAlertAsync("Operation Failed", "One or more empty text fields found");
            }
        }

        /// <summary>
        /// Go back to the Home Page View
        /// </summary>
        [RelayCommand]
        async void HomeBtn()
        {
            await Shell.Current.GoToAsync("..");
        }

        #endregion

        #region Helper Methods

       

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
