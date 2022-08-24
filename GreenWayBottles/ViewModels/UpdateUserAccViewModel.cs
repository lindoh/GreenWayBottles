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
            User = new();
            LoadData();
            alerts = new();
           
        }

        #endregion

        #region Class Members
        DatabaseService dataService;

        [ObservableProperty]
        Users user;

        AlertService alerts;

        [ObservableProperty]
        ObservableCollection<Users> usersList;
        #endregion

        #region Helper Methods
        void LoadData()
        {
            
            UsersList = new ObservableCollection<Users>(dataService.GetAll());           
        }


        #endregion
    }
}
