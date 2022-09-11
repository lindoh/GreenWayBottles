using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using System.Collections.ObjectModel;

//      TO DO
//Allow the user to see their info before deletion

namespace GreenWayBottles.ViewModels
{
    public partial class DeleteUserAccViewModel : ObservableObject
    {
        public DeleteUserAccViewModel()
        {
            dataService = new DatabaseService();
            alerts = new AlertService();
            User = new Users();
            UsersList = new ObservableCollection<Users>();
            searchService = new SearchService();
        }

        #region Class Properties
        //Database service object
        DatabaseService dataService;

        SearchService searchService;

        //Alert service object
        AlertService alerts;

        //The current user
        [ObservableProperty]
        Users user;

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

        [RelayCommand]
        async void Delete()
        {
            bool isDeleted = dataService.Delete(user.Id, selectedUser);

            if(isDeleted)
            {
                await alerts.ShowAlertAsync("Operation Successful", "User Account Deleted Successfully");
            }
            else
            {
                await alerts.ShowAlertAsync("Operation Failed", "User Account Could Not Be Deleted");
            }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// The selectedItem method updates the User object
        /// with the selected user from the ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void selectedItem(object sender, SelectedItemChangedEventArgs args)
        {
            User = args.SelectedItem as Users;
        }
        #endregion
    }
}
 