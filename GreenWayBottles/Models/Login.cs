﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class Login : ObservableObject
    {
        public Login()
        {
            IsLoggedIn = false;
        }

        //Username can be an Email or any combination of text
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        static bool isLoggedIn;

        [ObservableProperty]
        int adminId;

        [ObservableProperty]
        static int bBCId;
    }


}
