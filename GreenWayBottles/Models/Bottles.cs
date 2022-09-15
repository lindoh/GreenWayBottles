using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class BottlesDataSource : ObservableObject
    {
        public BottlesDataSource()
        {

        }

        #region Class Properties
       

        [ObservableProperty]
        int quantity;

        [ObservableProperty]
        double amount;

        #endregion
    }
}
