﻿using GreenWayBottles.Services;
using GreenWayBottles.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;



namespace GreenWayBottles.ViewModels
{

    public enum ModesOfPay
    {
        Cash,
        Bank,
        MobileMoney
    };
    public partial class CaptureBottlesViewModel : ObservableObject
    {
        public CaptureBottlesViewModel()
        {
            dataService = new DatabaseService();
            searchService = new SearchService();
            alerts = new AlertService();
            user = new Users();
            currentAdmin = new LoginViewModel();
            bottleData = new BottleDataSource();
            capturedBottles = new ObservableCollection<Bottles>();
            selectedUser = "Collector";
            GetBottles();
            Amount = 0.0;
            CaptureBottleDisplay = true;
            PaymentsDisplay = !captureBottleDisplay;
            display_0 = display_1 = display_2 = false;
        }

        

        #region Class Properties
        DatabaseService dataService;
        SearchService searchService;
        AlertService alerts;

        [ObservableProperty]
        Users user;

        [ObservableProperty]
        LoginViewModel currentAdmin;

        [ObservableProperty]
        ObservableCollection<Users> usersList;

        [ObservableProperty]
        string selectedUser;

        [ObservableProperty]
        BottleDataSource bottleData;

        [ObservableProperty]
        Bottles bottle;

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

        //Payment Method to be used for current transaction
        [ObservableProperty]
        int paymentMethod;

        //Switch Display Between capturing bottle data to payment section
        [ObservableProperty]
        bool captureBottleDisplay;

        [ObservableProperty]
        bool paymentsDisplay;

        //Switch display between Cash/Bank/MobileMoney Payment methods
        [ObservableProperty]
        bool display_0;

        [ObservableProperty]
        bool display_1;

        [ObservableProperty]
        bool display_2;

        #endregion

        #region Button Methods

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

        [RelayCommand]
        public async void Submit()
        {
            bool isSubmitted = false;

            if (capturedBottles.Count > 0)
            {
                isSubmitted = dataService.CaptureBottles(capturedBottles);

                if (isSubmitted)
                {
                    await alerts.ShowAlertAsync("Operation Successful", "Collected bottle(s) data saved successfully!");

                    //Hide 
                    CaptureBottleDisplay = false;
                    PaymentsDisplay = !captureBottleDisplay;
                }
                else
                    await alerts.ShowAlertAsync("Operation Failed", "Couldn't save data successfully, something went wrong");
            }
            else
                await alerts.ShowAlertAsync("Operation Failed", "Bottle data was not captured succesfully, please try again!!");
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

            private void Clear()
            {
                bottleData.Size = null;
                Quantity = 0;
            }

            #endregion
    } 
}
