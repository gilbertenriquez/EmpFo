using EmpFo.Models;
using EmpFo.Pages;
using Plugin.Connectivity;

namespace EmpFo;


public partial class MainPage : ContentPage
{

    Admin admin = new Admin();
	public MainPage()
	{
		InitializeComponent();
	}

    private async void BTNlogin_Clicked(object sender, EventArgs e)
    {
        var result = await admin.AdminLogin(txtemail.Text, txtpass.Text);

        if (string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtpass.Text))
        {
            await DisplayAlert("Alert!", "Please Fill up your Email or Password!", "Got it!");
            txtemail.Text = "";
            txtpass.Text = "";
            return;
        }
        progressLoading.IsVisible = true;
        if (result)
        {
            await DisplayAlert("Alert!", "Access Granted!", "OK!");
            txtemail.Text = "";
            txtpass.Text = "";
            Application.Current!.MainPage = new AppShell();
            progressLoading.IsVisible = false;
            return;

        }
        IC_check();
        await DisplayAlert("Alert!", "Access Denied!", "OK!");
        progressLoading.IsVisible = false;
        txtemail.Text = "";
        txtpass.Text = "";
    }

    private async void IC_check()
    {
        if (CrossConnectivity.Current.IsConnected)
        {
            return;
        }
        await DisplayAlert("Alert", "No Internet Connection", "OK!");
        return;
    }


    private async void signup_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SigninPage());
    }
}

