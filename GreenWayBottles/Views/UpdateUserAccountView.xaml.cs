
using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class UpdateUserAccountView : ContentPage
{
    UpdateUserAccViewModel viewModel;
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

	private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs args)
	{
		if (AdminRadioBtn.IsChecked)
			viewModel.SelectedUser = "Admin";
		else if (CollectorRadioBtn.IsChecked)
			viewModel.SelectedUser = "Collector";
	}
}