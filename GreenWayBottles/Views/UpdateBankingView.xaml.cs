using GreenWayBottles.ViewModels;

namespace GreenWayBottles.Views;

public partial class UpdateBankingView : ContentPage
{
	public UpdateBankingView()
	{
		InitializeComponent();
		viewModel = new UpdateBankingViewModel();
       // bankingView = new UpdateBankingView_1();    
        BindingContext = viewModel;
       // BindingContext = bankingView;
	}

	UpdateBankingViewModel viewModel;
  //  UpdateBankingView_1 bankingView;


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