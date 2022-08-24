﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenWayBottles.Models;
using GreenWayBottles.Services;

//TO DO!!
//ADD EMAIL VERIFICATION

namespace GreenWayBottles.ViewModels
{ 
    public partial class CreateUserAccViewModel : ObservableObject
    {
        #region Default Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CreateUserAccViewModel()
        {
            User = new Users();
            dataService = new DatabaseService();
            alerts = new AlertService();
        }
        #endregion

        #region Class Members
        DatabaseService dataService;

        [ObservableProperty]
        private Users user;

        AlertService alerts;

        #endregion

        #region Helper Methods
        /// <summary>
        /// The Save Method calls databaseService method to
        /// Save the user data in the database
        /// </summary>
        [RelayCommand]
        async void Save()
        {
            if (user.IdNumber.Length != 13)
            {
                await alerts.ShowAlertAsync("Operation Failed", "Id Number must be 13 digits long");
            }
            else if (CheckTextFields())
            {
                dataService.SaveData(user);
                await alerts.ShowAlertAsync("Success", "User Account Created Successfully");
                Clear();    //Clear text fields
            }
            else
            {
                await alerts.ShowAlertAsync("Operation Failed", "One or more empty text fields found");
            }
            
                
        }

        /// <summary>
        /// Check if any text fields are empty
        /// </summary>
        /// <returns>Return false if empty else return True</returns>
        bool CheckTextFields()
        {
            bool emptyFields = false;

            if (!(user.FirstName == "" || user.LastName == "" || user.IdNumber == "" ||
                user.Gender == "" || user.HighestQlfn == "" || user.IncomeRange == "" ||
                user.Email == "" || user.CellNumber == "" || user.StreetAddress == "" ||
                user.Suburb == "" || user.City == "" || user.Province == "" || user.Country == ""))
            {
                emptyFields = true;
               
            }

            return emptyFields;
        }

        /// <summary>
        /// Clear all text fields
        /// </summary>
        void Clear()
        {
            user.FirstName = "";
            user.LastName = "";
            user.IdNumber = "";
            user.Gender = ""; 
            user.HighestQlfn = "";
            user.IncomeRange = "";
            user.Email = "";
            user.CellNumber = "";
            user.StreetAddress = "";
            user.Suburb = "";
            user.City = "";
            user.Province = "";
            user.Country = "";
        }

        #endregion
    }
}
