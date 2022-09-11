using GreenWayBottles.Services;
using GreenWayBottles.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace GreenWayBottles.ViewModels
{
    public partial class UpdateUserAccViewModel : ObservableObject
    {
        #region Default Constructor
        public UpdateUserAccViewModel()
        {
            dataService = new DatabaseService();
            User = new Users();
            usersList = new ObservableCollection<Users>();
            alerts = new AlertService();
            createUserAccViewModel = new CreateUserAccViewModel();  
        }

        #endregion

        #region Class Properties
        //Database service object
        DatabaseService dataService;

        //CreateUserAccViewModel
        //To assist with common methods needed by this
        //ViewModel Class
        CreateUserAccViewModel createUserAccViewModel;

        //Alert service object
        AlertService alerts;

        [ObservableProperty]
        Users user;

        //To store the list of users
        [ObservableProperty]
        ObservableCollection<Users> usersList;

        //Which user details are being updated
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
            if (selectedUser == "Collector")
                UsersList = new ObservableCollection<Users>(dataService.SearchCollector(name));
            else if (selectedUser == "Admin")
                usersList = new ObservableCollection<Users>(dataService.SearchAdmin(name));
            else
                await alerts.ShowAlertAsync("Search Operation Failed", "The User Category Must be Selected Above");
        }

        /// <summary>
        /// Update Method calls the Database service Update Method
        /// to update the User's details
        /// </summary>
        [RelayCommand]
        async void Update()
        {
            if (user.IdNumber.Length != 13)
            {
                await alerts.ShowAlertAsync("Operation Failed", "Id Number must be 13 digits long");
            }
            else if (createUserAccViewModel.CheckTextFields(this.user))
            {
                bool isUpdated = dataService.Update(user);

                if(isUpdated)
                {
                    await alerts.ShowAlertAsync("Success", "User Account Updated Successfully");
                    createUserAccViewModel.Clear(this.user);    //Clear text fields
                }
            }
            else
            {
                await alerts.ShowAlertAsync("Operation Failed", "One or more empty text fields found");
            }
        }

        #endregion

        #region Helper Methods

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
