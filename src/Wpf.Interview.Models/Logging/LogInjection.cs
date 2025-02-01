using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Wpf.Interview.Models.Logging;

public static class LogInjection
{
    public static IServiceCollection RegisterLogging(this IServiceCollection services)
    {
        services.AddLogging(builder =>
            builder
            .ClearProviders()
            .AddConsole()
            .SetMinimumLevel(LogLevel.Information));
        return services;

    }
}
