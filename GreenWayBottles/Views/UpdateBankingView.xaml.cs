using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class UpdateBankingView : ContentPage
{
	public UpdateBankingView()
	{
		InitializeComponent();
		viewModel = new UpdateBankingViewModel();  
        BindingContext = viewModel;
	}

	UpdateBankingViewModel viewModel;


    private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        viewModel.selectedItem(sender, args);
    }

}