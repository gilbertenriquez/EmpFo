using EmpFo.Models;
using EmpFo.Service;
using System;
using System.Text.RegularExpressions;

namespace EmpFo.Pages;

public partial class AddPage : ContentPage
{
	Employee employee = new Employee();

    //UploadImage uploadImage {get; set;}  

	public AddPage()
	{
		InitializeComponent();
       //uploadImage = new UploadImage();
	}

	private async void BTN_addEmp_Clicked(object sender, EventArgs e)
	{
        if (string.IsNullOrEmpty(Fname.Text) || string.IsNullOrEmpty(Mname.Text) ||
            string.IsNullOrEmpty(Lname.Text) || string.IsNullOrEmpty(Email.Text) ||
            string.IsNullOrEmpty(phonenum.Text) || string.IsNullOrEmpty(Haddress.Text) ||
            string.IsNullOrEmpty(JobP.Text))
        {
            await DisplayAlert("Alert", "Please Fill up all fields", "Got it");
            return;
        }



        var email = Email.Text;
        var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9A-Z]((\\.(?!\\.))|" +
            "[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))" +
            "(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z]" +
            "[-\\w]*[0-9a-z]*\\.)+[a-z0-9]" +
            "[\\-a-z0-9]{0,22}[a-z0-9]))$";

        

        if (Regex.IsMatch(email, emailPattern))
        {
           

        }
        else
        {
            await DisplayAlert("Alert", "Email Is Not Valid", "Got it");
            return;
        }

        progressLoading.IsVisible = true;
        var a = await employee.Addemployees(Fname.Text, Mname.Text, Lname.Text, Email.Text,phonenum.Text,Haddress.Text, JobP.Text);
        if (a)
		{           
            await DisplayAlert("Alert", "Employee Successfully Added", "OK");
            await Navigation.PopAsync();
            progressLoading.IsVisible = false;
            return;
		}
	
        await DisplayAlert("Alert", "Employee Not Successfully Added or Maybe The Email is Already Taken", "OK");
        progressLoading.IsVisible = false;
    }



	private async void btncancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();

	}

    //private async void UploadImage_Clicked(object sender, EventArgs e)
    //{
    //    var img = await uploadImage.OpenMediaPickerAsync();
    //    var imagefile = await uploadImage.Upload(img);


    //    Image_Upload.Source = ImageSource.FromStream(() =>
    //    uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64)));
    //}
}