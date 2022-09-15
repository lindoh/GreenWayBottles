using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class BottleDataSource : ObservableObject
    {
        public BottleDataSource()
        {

        }

        [ObservableProperty]
        int bottleDataSourceId;

        [ObservableProperty]
        string bottleName;

        [ObservableProperty]
        string size;
    }
}
