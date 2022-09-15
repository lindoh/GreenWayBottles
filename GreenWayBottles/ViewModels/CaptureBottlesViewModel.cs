using GreenWayBottles.Services;
using GreenWayBottles.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace GreenWayBottles.ViewModels
{
    public partial class CaptureBottlesViewModel : ObservableObject
    {
        public CaptureBottlesViewModel()
        {
            dataService = new DatabaseService();
            searchService = new SearchService();
            user = new Users();
            bottle = new BottlesDataSource();
            selectedUser = "Collector";
            GetBottles();
        }

        #region Class Properties
        DatabaseService dataService;
        SearchService searchService;

        [ObservableProperty]
        Users user;

        [ObservableProperty]
        ObservableCollection<Users> usersList;

        [ObservableProperty]
        string selectedUser;

        [ObservableProperty]
        BottlesDataSource bottle;

        [ObservableProperty]
        ObservableCollection<BottleDataSource> bottlesList;

        #endregion

        #region Button Methods

        [RelayCommand]
        public void Search(string name)
        {
            UsersList = searchService.FindUser(name, selectedUser);
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

        public void GetBottles()
        {
            BottlesList = new ObservableCollection<BottleDataSource>(dataService.GetBottleList());
        }

        #endregion
    }
}
