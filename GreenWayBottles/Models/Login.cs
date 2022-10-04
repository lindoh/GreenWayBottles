using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class Login : ObservableObject
    {
        public Login()
        {
            
        }

        //Username can be an Email or any combination of text
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        bool isLoggedIn;

        [ObservableProperty]
        bool isBBCUpdated;

        [ObservableProperty]
        int adminId;

        [ObservableProperty]
        int bBCId;
    }


}
