using ApisJM.Data;

namespace ApisJM;

public partial class App : Application
{
    public static DogsJmDataBase DogsRepo { get; private set; }
    public App(DogsJmDataBase repo)
    {
        InitializeComponent();

        MainPage = new AppShell();
        DogsRepo = repo;
    }
}
