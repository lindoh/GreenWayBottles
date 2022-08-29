using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;
using System.Collections.ObjectModel;

namespace GreenWayBottles.ViewModels
{
    public partial class DeleteUserAccViewModel : ObservableObject
    {
        public DeleteUserAccViewModel()
        {
            dataService = new DatabaseService();
            alerts = new AlertService();
            user = new Users();
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

        #endregion

        #region ViewModel Buttons
        /// <summary>
        /// Search method calls the Database service method
        /// to search for the current user in the database
        /// </summary>
        [RelayCommand]
        void Search(string name)
        {
            UsersList = new ObservableCollection<Users>(dataService.SearchCollector(name));
        }

        [RelayCommand]
        async void Delete()
        {
            bool isDeleted = dataService.Delete(user.Id);

            if(isDeleted)
            {
                await alerts.ShowAlertAsync("Operation Successful", "User Account Deleted Successfully");
                return;
            }
            else
            {

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
