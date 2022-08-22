using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;



namespace GreenWayBottles.ViewModels
{ 
    public partial class CreateUserAccViewModel : ObservableObject
    {
        #region Default Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CreateUserAccViewModel()
        {
            User = new Users();
            dataService = new DatabaseService();
        }
        #endregion

        

        #region Class Members
        DatabaseService dataService;

        [ObservableProperty]
        private Users user;

        #endregion

        #region Helper Methods
        /// <summary>
        /// The Save Method calls databaseService method to
        /// Save the user data in the database
        /// </summary>
        [RelayCommand]
        async void Save()
        {
            if (CheckTextFields())
            {
                dataService.SaveData(user); 
                
            }
            
                
        }

        bool CheckTextFields()
        {
            bool emptyFields = false;

            if(user.FirstName == "" || user.LastName == "" || user.IdNumber == "" || 
                user.Gender == "" || user.HighestQlfn == "" || user.IncomeRange == "" ||
                user.Email == "" || user.CellNumber == "" || user.StreetAddress == "" ||
                user.Suburb == "" || user.City == "" || user.Province == "" || user.Country == "")
                emptyFields = true;

            return emptyFields;
        }


        #endregion
    }
}
