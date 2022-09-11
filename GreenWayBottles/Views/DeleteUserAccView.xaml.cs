
using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class DeleteUserAccView : ContentPage
{
	public DeleteUserAccView()
	{
		InitializeComponent();
        viewModel = new DeleteUserAccViewModel();
        BindingContext = viewModel;
	}

    DeleteUserAccViewModel viewModel;

    private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
        viewModel.selectedItem(sender, args);
	}

	private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
        if (AdminRadioBtn.IsChecked)
            viewModel.SelectedUser = "Admin";
        else if (CollectorRadioBtn.IsChecked)
            viewModel.SelectedUser = "Collector";
    }
}