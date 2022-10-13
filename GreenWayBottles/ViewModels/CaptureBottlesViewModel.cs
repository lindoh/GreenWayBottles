using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;

/* Unmerged change from project 'GreenWayBottles (net6.0-ios)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
After:
using GreenWayBottles.Services;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-maccatalyst)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
After:
using GreenWayBottles.Services;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-windows10.0.19041.0)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
After:
using GreenWayBottles.Services;
*/
using GreenWayBottles.Services;
using System.Collections.ObjectModel;
/* Unmerged change from project 'GreenWayBottles (net6.0-ios)'
Before:
using CommunityToolkit.Mvvm.Input;
After:
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-maccatalyst)'
Before:
using CommunityToolkit.Mvvm.Input;
After:
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'GreenWayBottles (net6.0-windows10.0.19041.0)'
Before:
using CommunityToolkit.Mvvm.Input;
After:
using System.Collections.ObjectModel;
*/


/*TO DO
    */

namespace GreenWayBottles.ViewModels
{ 
    public partial class CaptureBottlesViewModel : ObservableObject
    {
        #region Default Constructor
        public CaptureBottlesViewModel()
        {
            dataService = new DatabaseService();
            searchService = new SearchService();
            alerts = new AlertService();
            user = new Users();
            banker = new Banking();
            currentAdmin = new LoginViewModel();
            bottleData = new BottleDataSource();
            capturedBottles = new ObservableCollection<Bottles>();
            selectedUser = "Collector";
            GetBottles();
            Amount = 0.0;
            CaptureBottleDisplay = true;
            PaymentsDisplay = !captureBottleDisplay;
            display_0 = display_1 = false;
            transactions = new Transaction();
           
        }

        #endregion

        #region Class Properties
        DatabaseService dataService;
        SearchService searchService;
        AlertService alerts;

        [ObservableProperty]
        Users user;

        [ObservableProperty]
        Banking banker;

        [ObservableProperty]
        LoginViewModel currentAdmin;

        [ObservableProperty]
        ObservableCollection<Users> usersList;

        [ObservableProperty]
        string selectedUser;

        //Bottles saved in the database are represented with this variable
        [ObservableProperty]
        BottleDataSource bottleData;

        //Represents a given bottle
        [ObservableProperty]
        Bottles bottle;

        //List of Bottle Id's
        [ObservableProperty]
        List<int> bottleIdList;

        //List of Bottles from the database
        [ObservableProperty]
        ObservableCollection<BottleDataSource> bottlesList;

        //The quantity of bottles submitted by the Collector
        [ObservableProperty]
        int quantity;

        //The amount due to the collector
        [ObservableProperty]
        static double amount;

        [ObservableProperty]
        string amountString;

        //Store the collected bottles in the list before submition to database
        [ObservableProperty]
        ObservableCollection<Bottles> capturedBottles;

        //Switch Display Between capturing bottle data to payment section
        [ObservableProperty]
        bool captureBottleDisplay;

        //Used to select the Payment Method available to the user
        [ObservableProperty]
        bool paymentsDisplay;

        //Switch display between Bank/MobileMoney Payment methods
        [ObservableProperty]
        bool display_0;

        [ObservableProperty]
        bool display_1;

        [ObservableProperty]
        Transaction transactions;

        #endregion

        #region Button Methods

        /// <summary>
        /// Update the List of User's by searching the database
        /// </summary>
        /// <param name="name"> User's Name from SearchBox</param>
        [RelayCommand]
        public void Search(string name)
        {
            UsersList = searchService.FindUser(name, selectedUser);
        }

        [RelayCommand]
        public async void Add_and_Calculate()
        {
            //Confirm if a User is selected
            if (user.Id == 0)
            {
                await alerts.ShowAlertAsync("Operation Failed", "Please Search and Select User");
                return;
            }

            if (quantity == 0)
            {
                await alerts.ShowAlertAsync("Operation Failed", "Quantity Cannot be Zero");
                return;
            }

            //Update the Bottle Object
            if (bottleData.BottleDataSourceId != 0)
            {
                bottle = new Bottles();
                //Calculate amount due
                CalculateAmount();

                Bottle.BottleName = BottleData.BottleName;
                Bottle.Quantity = quantity;
                Bottle.BottleDataSourceId = BottleData.BottleDataSourceId;
                Bottle.CollectorId = user.Id;
                Bottle.BBCId = currentAdmin.UserLogin.BBCId;
                Bottle.Amount = amount;
                Bottle.AdminId = currentAdmin.UserLogin.AdminId;

                //Update and Display Captured Bottles
                capturedBottles.Insert(0, Bottle);
            }
            else
                await alerts.ShowAlertAsync("Operation Failed", "Please Login to continue.");

            //Reset Bottle size and Quantity
            Clear();
        }

        /// <summary>
        /// Submit Captured Bottles to the database as a record and 
        /// alert the user of the outcome.
        /// </summary>
        [RelayCommand]
        public async void Submit()
        {
            bool isSubmitted = false;

            if (capturedBottles.Count > 0)
            {
                bottleIdList = new List<int>();

                foreach (Bottles bottle in capturedBottles)
                {
                    isSubmitted = dataService.CaptureBottles(bottle);

                    if (!isSubmitted)
                    {
                        await alerts.ShowAlertAsync("Operation Failed", "Couldn't save data successfully, something went wrong");  
                    }
                    else
                        BottleIdList.Insert(0, dataService.GetBottleId(bottle));
                }           

                if (isSubmitted)
                {
                    await alerts.ShowAlertAsync("Operation Successful", "Collected bottle(s) data saved successfully!");

                    //Switch between the CaptureBottle Display and Payment Display in the CaptureNewBottlesView
                    CaptureBottleDisplay = false;
                    PaymentsDisplay = !captureBottleDisplay;
                }
                else
                    await alerts.ShowAlertAsync("Operation Failed", "Couldn't save data successfully, something went wrong");
            }
            else
                await alerts.ShowAlertAsync("Operation Failed", "Bottle data was not captured succesfully, please try again!!");
        }

        /// <summary>
        /// Submit the Transaction file showing the collected bottle information,
        /// Collector Details, and BuyBackCentre Details
        /// </summary>
        [RelayCommand]
        async public void SubmitTransaction()
        {
            //Set the transaction type
            if (display_0)   //If display is set to Banking Display
                transactions.TransactionType = "Bank Payment";
            else if (display_1)      //If display is set to MobileMoney Display
                transactions.TransactionType = "Mobile Money Payment";

            //Set the Date and Time to the current computer time
            transactions.LocalDate = DateTime.Now;

            if (transactions.LocalDate.Hour < 6 || transactions.LocalDate.Hour > 18)
            {
                await alerts.ShowAlertAsync("Operation Failed", "Time out of business hours");
                return;
            }

            //Find the Banking details
            Banker = dataService.SearchBanking(user.Id);
            if (banker != null)
                transactions.BankDetailsId = banker.BankDetailsId;

            bool isSaved = false;

            if(bottleIdList == null)
            {
                await alerts.ShowAlertAsync("Operation Failed", "No bottles were captured, please capture bottles first");
                return;
            }
            else
            {
                foreach (int id in bottleIdList)
                {
                    transactions.BottleId = id;
                    isSaved = dataService.TransRecord(transactions);

                    if (!isSaved)
                    {
                        await alerts.ShowAlertAsync("Operation Failed", "One or more transaction records could not be saved");
                        return;
                    }
                }

                if (isSaved)
                    await alerts.ShowAlertAsync("Operation Successful", $"Captured Bottles Transaction Record Saved Successfully on {transactions.LocalDate}");
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

        public void selectedBottle(object sender, SelectedItemChangedEventArgs args)
        {
            BottleData = args.SelectedItem as BottleDataSource;
        }

        public void GetBottles()
        {
            BottlesList = new ObservableCollection<BottleDataSource>(dataService.GetBottleList());
        }

        private void CalculateAmount()
        {
            string bottleSize;

            if (bottleData.Size != null)
            {
                bottleSize = bottleData.Size.Replace("ml", string.Empty);
                bottleSize = bottleSize.Trim();

                int size = Int32.Parse(bottleSize);

                if (size > 0 && size < 2000)
                    Amount += Quantity;
                else if (size >= 2000)
                    Amount += Quantity * 1.5;

                AmountString = $"R{amount}";

            }
            else
            {
                alerts.ShowAlertAsync("Operation Failed", "Select a bottle name from the list and enter quantity value");
                return;
            }
        }

        /// <summary>
        /// Show Banking Details for the current User/Collector for confirmation
        /// </summary>
        public void UpdateBanker()
        {
            if (user.Id != 0)
            {
                //Search the database for the user's banking details
                Banker = dataService.SearchBanking(user.Id);

            }
        }

        private void Clear()
        {
            bottleData.Size = null;
            Quantity = 0;
        }

        #endregion
    }
}
