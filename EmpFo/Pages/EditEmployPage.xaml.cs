using EmpFo.Models;
using static EmpFo.App;

namespace EmpFo.Pages;

public partial class EditEmployPage : ContentPage
{
	private Employee employees = new();
	public EditEmployPage()
	{
		InitializeComponent();
	}


    protected override void OnAppearing()
    {

        base.OnAppearing();
        entryFirst.Text =firstname;
        entryMname.Text = middlename;
        entryLast.Text = lastname;
        entryHaddress.Text = homeaddress;
		entryphone.Text = phone;
        entryjobpos.Text = jobposition;

    }


	private async void BTN_Update_Clicked(object sender, EventArgs e)
	{
		var a = await employees.EditEmployData(entryFirst.Text,
			entryMname.Text, entryLast.Text, entryphone.Text,
			entryHaddress.Text, entryjobpos.Text);

		progressLoading.IsVisible = true;
		if (!a) { 
			await DisplayAlert("Alert", "Data Successfully Updated", "OK");
		await Navigation.PopAsync();
		progressLoading.IsVisible = false;
		return;
	    }	
		await DisplayAlert("Alert", "Data Not Successfully Update", "");
        progressLoading.IsVisible = false;
    
    }
	private async void BTN_exit_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();	
	}

	private void btnmodify_Clicked(object sender, EventArgs e)
	{

	}
}