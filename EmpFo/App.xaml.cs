using Microsoft.Maui.Platform;
using Firebase.Database;

namespace EmpFo;

public partial class App : Application
{
    public static FirebaseClient client = new("https://employeeinfodb-default-rtdb.asia-southeast1.firebasedatabase.app/");
    public static string email, key,firstname,middlename,lastname,homeaddress,jobposition,phone;
    public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new Pages.WelcomePage());
    }
}
