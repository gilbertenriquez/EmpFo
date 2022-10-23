using EmpFo.Models;
using Microsoft.Maui.Graphics.Text;
using Plugin.Connectivity;
using System.Text.RegularExpressions;

namespace EmpFo.Pages;

public partial class SigninPage : ContentPage
{
    private Admin admin = new();
    public SigninPage()
	{
		InitializeComponent();
	}

    private async void btn_register_Clicked(object sender, EventArgs e)
    {
        var email = txtmail.Text;
        var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|" +
            "[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))" +
            "(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z]" +
            "[-\\w]*[0-9a-z]*\\.)+[a-z0-9]" +
            "[\\-a-z0-9]{0,22}[a-z0-9]))$";

        if (Regex.IsMatch(email, emailPattern))
        {
           
            
        }
        else
        {
            await DisplayAlert("Alert", "Email is not Valid", "OK");
            return;
        }


        if (string.IsNullOrEmpty(txtfname.Text) || string.IsNullOrEmpty(txtlname.Text) || string.IsNullOrEmpty(txtmail.Text) || string.IsNullOrEmpty(txtpw.Text))
        {
            await DisplayAlert("Alert!", "Fill up the Empty Fields", "Got it!");
            return;
        }

        if(txtcfpw.Text == txtpw.Text)
        {

        }
        else
        {
            await DisplayAlert("Alert!", "Password is Not Match", "Ok!");
            return;
        }


        progressLoading.IsVisible = true;
        var result = await admin.Addadmin(txtfname.Text, txtlname.Text, txtmail.Text, txtpw.Text);       
        if (result == true)
        {
            await DisplayAlert("Alert!", "Account Successfully Created", "Ok!");
            await Navigation.PopAsync();
            progressLoading.IsVisible = false;
            return;

        }
        else
        {
            
            await DisplayAlert("Alert", "Account Not Registered or your Email is already Exist or No Internet Connection", " OK!");
            progressLoading.IsVisible = false;
        }


    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
	{
        await Navigation.PopAsync();
    }
}