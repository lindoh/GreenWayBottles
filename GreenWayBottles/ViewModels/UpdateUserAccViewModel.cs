using GreenWayBottles.Services;
using GreenWayBottles.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace GreenWayBottles.ViewModels
{
    public partial class UpdateUserAccViewModel : ObservableObject
    {
        #region Default Constructor
        public UpdateUserAccViewModel()
        {
            dataService = new();
            user = new();
            alerts = new();
        }

        #endregion

        #region Class Members
        DatabaseService dataService;

        [ObservableProperty]
        Users user;

        AlertService alerts;

        ObservableCollection<Users> usersList;
        #endregion


    }
}
