using EmpFo.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;

namespace EmpFo.Pages;

public partial class HomePage : ContentPage
{
	private Employee getemployeeslist = new();

	public HomePage()
	{
		InitializeComponent();

		Employeelist.ItemsSource = getemployeeslist.GetEmployeesList();

	}



	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPage());
	}

	private async void Employeelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		App.email = (e.CurrentSelection.FirstOrDefault() as Employee)?.eMail;
		App.key = await getemployeeslist.GetEmployKey(App.email);
	}

	private async void EditEmploy_Clicked(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(App.key))
		{
			await Navigation.PushAsync(new EditEmployPage());
		}
		else
		{
			await DisplayAlert("Alert", "Please Select A Data To Edit", "OK!");
		}
	}

	private async void DeleteEmployess_Clicked(object sender, EventArgs e)
	{

		if (!string.IsNullOrEmpty(App.key))
		{

		}
		else
		{
			await DisplayAlert("Alert", "Please Select A Data To Delete", "OK!");
			return;
		}
		var result = await DisplayAlert("Alert", "Are You Sure To Delete", "YES", "NO");

		if (result)
		{
			await getemployeeslist.DeleteEmploydata();
			return;
		}

	}


	private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(SearchBar.Text))
		{
			Employeelist.ItemsSource = getemployeeslist.GetEmployeesList();
			return;
		}
		else
		{

			Employeelist.ItemsSource = await getemployeeslist.FindEmployee(SearchBar.Text);
			return;
		}
	}
}


