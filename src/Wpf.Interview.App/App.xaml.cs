using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Wpf.Interview.App;
using Wpf.Interview.Common.Navigation;
using Wpf.Interview.Models;

namespace Wpf.Interview.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
        ServiceCollection services = new();
        services.RegisterAppServices();
        services.AddSingleton<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        INavigationService navigationService = _serviceProvider.GetRequiredService<INavigationService>();
        navigationService.Register();

        MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void OnExit(object sender, ExitEventArgs e)
    {
        // Dispose of services if needed
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
