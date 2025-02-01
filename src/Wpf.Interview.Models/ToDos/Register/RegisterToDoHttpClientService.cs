using Microsoft.Extensions.DependencyInjection;

using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Models.Handlers;

namespace Wpf.Interview.Models.ToDos.Register;

public static class RegisterToDoHttpClientService
{
    public static IServiceCollection RegisterToDoHttpClient(this IServiceCollection services)
    {
        services.AddTransient<LoggingDelegatingHandler>();
        services.AddTransient<RetryDelegatingHandler>();

        services.AddHttpClient<IToDoService, ToDoService>(client => client.BaseAddress = new Uri(IToDoService.ToDoBaseUri))
        .AddHttpMessageHandler<LoggingDelegatingHandler>()
        .AddHttpMessageHandler<RetryDelegatingHandler>();


        return services;

    }
}
