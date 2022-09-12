
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using System.Collections.ObjectModel;

namespace GreenWayBottles.ViewModels
{
    public partial class UpdateBankingViewModel : ObservableObject
    {
        #region Default Constructor
        public UpdateBankingViewModel()
        {
            user = new Users();
            banking = new Banking();
            dataService = new DatabaseService();
            alerts = new AlertService();
            searchService = new SearchService();
        }
        #endregion

        #region Class Properties
       
        
        DatabaseService dataService;
        AlertService alerts;
        SearchService searchService;

        [ObservableProperty]
        Users user;

        [ObservableProperty]
        Banking banking;

        //To store the list of users
        [ObservableProperty]
        ObservableCollection<Users> usersList;

        [ObservableProperty]
        string selectedUser;

        #endregion

        #region ViewModel Buttons
        /// <summary>
        /// Search method calls the Database service method
        /// to search for the current user in the database
        /// </summary>
        [RelayCommand]
        void Search(string name)
        {
            UsersList = searchService.FindUser(name, selectedUser);
        }

        /// <summary>
        /// The selectedItem method updates the User object
        /// with the selected user from the ListView
        /// </summary>
        public void selectedItem(object sender, SelectedItemChangedEventArgs args)
        {
            User = args.SelectedItem as Users;
        }


        #endregion
    }
}
