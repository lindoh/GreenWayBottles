using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class DeleteUserAccView : ContentPage
{
	public DeleteUserAccView()
	{
		InitializeComponent();
		deleteUserAccViewModel = new DeleteUserAccViewModel();
	}

	private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
		deleteUserAccViewModel.selectedItem(sender, args);
	}

	DeleteUserAccViewModel deleteUserAccViewModel;
}