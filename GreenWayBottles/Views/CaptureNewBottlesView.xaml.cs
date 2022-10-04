using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public enum ModesOfPay
{
    Cash,
    Bank,
    MobileMoney
};
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
		if (CashPaymentRadioBtn.IsChecked)
		{
			viewModel.PaymentMethod = (int)ModesOfPay.Cash;
			viewModel.Display_0 = true;
			viewModel.Display_1 = viewModel.Display_2 = !viewModel.Display_0;
		}
		else if (BankPaymentRadioBtn.IsChecked)
		{
			viewModel.PaymentMethod = (int)ModesOfPay.Bank;
			viewModel.Display_1 = true;
			viewModel.Display_0 = viewModel.Display_2 = !viewModel.Display_1;
		}

		else if (MobilePaymentRadioBtn.IsChecked)
		{
			viewModel.PaymentMethod = (int)ModesOfPay.MobileMoney;
            viewModel.Display_2 = true;
            viewModel.Display_0 = viewModel.Display_1 = !viewModel.Display_2;
        }
	}
}