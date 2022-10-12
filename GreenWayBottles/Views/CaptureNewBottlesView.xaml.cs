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

	/// <summary>
	/// Select a User from the ListView List and update the ViewModel selected user
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
		viewModel.selectedItem(sender, args);
	}

	private void bottlesListView_ItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
		viewModel.selectedBottle(sender, args);
	}

	/// <summary>
	/// Update the Payment Method as Choosen by the user from the Radio buttons
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private void PayMethodRadioBtn_CheckedChanged(object sender, CheckedChangedEventArgs args)
	{
		if (BankPaymentRadioBtn.IsChecked)
		{
			viewModel.Display_0 = true;
			viewModel.Display_1 = !viewModel.Display_0;

			//Show Updated Banking Details
			viewModel.UpdateBanker();
        }

        else if (MobilePaymentRadioBtn.IsChecked)
		{
            viewModel.Display_1 = true;
			viewModel.Display_0 = !viewModel.Display_1;
        }
	}
}