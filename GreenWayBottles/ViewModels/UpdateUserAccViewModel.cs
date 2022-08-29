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
            usersList = new ObservableCollection<Users>(dataService.GetAll(""));
            alerts = new AlertService();
        }

        #endregion

        #region Class Members
        DatabaseService dataService;

        AlertService alerts;

        [ObservableProperty]
        Users user;

        [ObservableProperty]
        ObservableCollection<Users> usersList;

        [RelayCommand]
        void Search(string query)
        {
            UsersList = new ObservableCollection<Users>(dataService.GetAll(query));
        }

        [RelayCommand]
        void Update()
        {

        }

        #endregion

        #region Helper Methods

        public void selectedItem(object sender, SelectedItemChangedEventArgs args)
        {
            User = args.SelectedItem as Users;
        }
        #endregion
    }
}
