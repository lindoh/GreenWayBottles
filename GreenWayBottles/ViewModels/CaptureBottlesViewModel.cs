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
            bottle = new BottleDataSource();    
            selectedUser = "Collector";
            GetBottles();
            Amount = 0.0;
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
        BottleDataSource bottle;

        [ObservableProperty]
        ObservableCollection<BottleDataSource> bottlesList;

        [ObservableProperty]
        int quantity;

        [ObservableProperty]
        static double amount;

        [ObservableProperty]
        string amountString;

        #endregion

        #region Button Methods

        [RelayCommand]
        public void Search(string name)
        {
            UsersList = searchService.FindUser(name, selectedUser);
        }

        [RelayCommand]
        public void Add_and_Calculate()
        {
            //Calculate amount due
            CalculateAmount();

            
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

        public void selectedBottle(object sender, SelectedItemChangedEventArgs args)
        {
            Bottle = args.SelectedItem as BottleDataSource;
        }
        public void GetBottles()
        {
            BottlesList = new ObservableCollection<BottleDataSource>(dataService.GetBottleList());
        }

        private void CalculateAmount()
        {
            string bottleSize;
            bottleSize = bottle.Size.Replace("ml", string.Empty);
            bottleSize = bottleSize.Trim();

            int size = Int32.Parse(bottleSize);

            if (size > 0 && size < 2000)
                Amount += Quantity;
            else if (size >= 2000)
                Amount += Quantity * 1.5;

            AmountString = $"R{amount}";
        }

        #endregion
    }
}
