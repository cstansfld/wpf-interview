using Microsoft.Extensions.DependencyInjection;
using Wpf.Interview.Common;
using Wpf.Interview.Common.Navigation;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.Users;
using Wpf.Interview.Models.Logging;
using Wpf.Interview.Models.Navigation;
using Wpf.Interview.Models.ToDos;
using Wpf.Interview.Models.ToDos.Register;
using Wpf.Interview.Models.Users;
using Wpf.Interview.Models.Users.Register;

namespace Wpf.Interview.Models;

public static class RegisterApp
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.RegisterLogging().RegisterToDoHttpClient()
            .RegisterUserHttpClient();

        services.AddSingleton<IToDoViewModel, ToDoViewModel>();
        services.AddSingleton<IUserViewModel, UserViewModel>();
        services.AddSingleton<IUserToDoViewModel, UserToDoViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();

        return services;
    }
}