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
            selectedUser = "Collector";
        }

        DatabaseService dataService;
        SearchService searchService;

        [ObservableProperty]
        Users user;

        [ObservableProperty]
        ObservableCollection<Users> usersList;

        [ObservableProperty]
        string selectedUser;

        [RelayCommand]
        public void Search(string name)
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
    }
}
