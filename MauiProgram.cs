using ApisJM.Data;
namespace ApisJM;

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
			});

        string dbPath = FileAccessHelper.GetLocalFilePath("dogs.db3");
        builder.Services.AddSingleton<DogsJmDataBase>(s => ActivatorUtilities.CreateInstance<DogsJmDataBase>(s, dbPath));

        return builder.Build();
	}
}
