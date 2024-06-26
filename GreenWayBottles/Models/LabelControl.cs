﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class LabelControl : ObservableObject
    {
        public LabelControl()
        {
            this.ShowLabel = false;

            AddMessages();
        }

        //Control the label
        [ObservableProperty]
        Color color;

        [ObservableProperty]
        string message;

        [ObservableProperty]
        bool showLabel;

        public Dictionary<string, string> messages;

        private void AddMessages()
        {
            messages = new Dictionary<string, string>();

            messages.Add("Access Granted", "The user has succesfully Logged In");
            messages.Add("Login Failed", "The user could not be found, Register a new account instead");
            messages.Add("Operation Failed", "One or more empty text fields found!");
            messages.Add("Delete Operation Successful", "User Account Deleted Successfully");
            messages.Add("Delete Operation Failed", "User Account Could Not Be Deleted");
        }
    }
}
