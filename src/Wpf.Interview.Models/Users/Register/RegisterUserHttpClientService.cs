using Microsoft.Extensions.DependencyInjection;
using Wpf.Interview.Common.Users;
using Wpf.Interview.Models.Handlers;

namespace Wpf.Interview.Models.Users.Register;

public static class RegisterUserHttpClientService
{
    public static IServiceCollection RegisterUserHttpClient(this IServiceCollection services)
    {
        services.AddTransient<LoggingDelegatingHandler>();
        services.AddTransient<RetryDelegatingHandler>();

        services.AddHttpClient<IUserService, UserService>(client =>
        {
            client.BaseAddress = new Uri(IUserService.UserBaseUri);
        })
        .AddHttpMessageHandler<LoggingDelegatingHandler>()
        .AddHttpMessageHandler<RetryDelegatingHandler>();


        return services;

    }
}
