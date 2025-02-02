using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wpf.Interview.Common.Navigation;
using Wpf.Interview.Models;

namespace Wpf.Interview.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<App> _logger;

    public App()
    {
        ServiceCollection services = new();
        services.RegisterAppServices();
        services.AddSingleton<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();
        _logger = _serviceProvider.GetRequiredService<ILogger<App>>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _logger.LogInformation("App Starting - Args {@Args}", $"[{string.Join(",", e.Args)}]");

        INavigationService navigationService = _serviceProvider.GetRequiredService<INavigationService>();
        navigationService.Register();

        MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _logger.LogInformation("App Exiting {ExitCode}", e.ApplicationExitCode);
        // Dispose of services if needed
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }

        base.OnExit(e);
    }
}
