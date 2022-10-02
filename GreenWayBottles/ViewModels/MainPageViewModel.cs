using CommunityToolkit.Mvvm.ComponentModel;
using GreenWayBottles.Models;

namespace GreenWayBottles.ViewModels
{
    [QueryProperty("IsBBCUpdated", "IsBBCUpdated")]
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
           
        }

        [ObservableProperty]
        static bool isLoggedIn;

        [ObservableProperty]
        static bool isBBCUpdated;

   

    }
}
