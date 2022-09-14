using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class CaptureNewBottlesView : ContentPage
{
	public CaptureNewBottlesView()
	{
		InitializeComponent();
		viewModel = new CaptureBottlesViewModel();
		BindingContext = viewModel;
	}

	CaptureBottlesViewModel viewModel;

	private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
		viewModel.selectedItem(sender, args);
	}
}