namespace maui466;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Mplus1-ExtraBold.otf", "Mplus");
				fonts.AddFont("NotoSansJP-Regular.otf", "Noto");
				fonts.AddFont("NotoSansJP-Regular.otf", "Noto-jp");
				fonts.AddFont("NotoSansSC-Regular.otf", "Noto-sc");
				fonts.AddFont("NotoSansTC-Regular.otf", "Noto-tc");
			});

		return builder.Build();
	}
}
