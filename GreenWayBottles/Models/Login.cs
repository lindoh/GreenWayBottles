using CommunityToolkit.Mvvm.ComponentModel;

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
        bool isLoggedIn;

        [ObservableProperty]
        int adminId;

        [ObservableProperty]
        int bBCId;
    }


}
