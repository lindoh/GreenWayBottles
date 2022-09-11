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
        }

        #region Class Properties
        //Database service object
        DatabaseService dataService;

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
        async void Search(string name)
        {
            if (selectedUser != null)
            {
                //Get the list of users that match the given name
                UsersList = new ObservableCollection<Users>(dataService.Search(name, selectedUser));

                //If the user is not found, notify the user
                if (usersList.Count == 0)
                    await alerts.ShowAlertAsync("Search Operation Failed", "User not found");
            }
            else
                await alerts.ShowAlertAsync("Search Operation Failed", "The User Category Must be Selected First");
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
 