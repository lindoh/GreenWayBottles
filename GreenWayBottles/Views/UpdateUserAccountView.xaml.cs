using GreenWayBottles.Models;
using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class UpdateUserAccountView : ContentPage
{
	public UpdateUserAccountView()
	{
		InitializeComponent();
		viewModel = new();
		BindingContext = viewModel;
	}
	private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
		viewModel.selectedItem(sender, args);
	}

	UpdateUserAccViewModel viewModel;
}