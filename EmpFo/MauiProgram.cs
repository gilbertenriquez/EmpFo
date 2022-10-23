using SkiaSharp.Views.Maui.Controls.Hosting;
namespace EmpFo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands-400.ttf", "fabrands");
                fonts.AddFont("fa-regular-400.ttf", "faregular");
                fonts.AddFont("fa-solid-400.ttf", "fasolid");
                fonts.AddFont("fa-v4compatibility-400.ttf", "facompa");
            });

		return builder.Build();
	}
}
