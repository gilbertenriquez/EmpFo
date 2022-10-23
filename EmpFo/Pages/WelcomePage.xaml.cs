namespace EmpFo.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	private async void btnlog_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MainPage());
    }
}