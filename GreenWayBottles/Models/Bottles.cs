using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class Bottles : ObservableObject
    {
        [ObservableProperty]
        int quantity;

        [ObservableProperty]
        int bottleDataSourceId;

        [ObservableProperty]
        int collectorId;

        [ObservableProperty]
        int bBCId;

        [ObservableProperty]
        double amount;
    }
}
