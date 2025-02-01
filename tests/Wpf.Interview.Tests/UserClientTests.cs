using Microsoft.Extensions.DependencyInjection;
using Wpf.Interview.Common.Users;
using Wpf.Interview.Models.Logging;
using Wpf.Interview.Models.Users.Register;

namespace Wpf.Interview.Tests;

public class UserClientTests
{
    private readonly ServiceProvider _serviceProvider;
    public UserClientTests()
    {
        var services = new ServiceCollection();
        services.RegisterLogging()
            .RegisterUserHttpClient();
        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetAllUsers()
    {
        const int MaxCount = 10;
        // default startIndex = 0, limit is 10
        IList<XUser>? results = await _serviceProvider.GetRequiredService<IUserService>().GetAllUsersAsync();
        Assert.NotNull(results);
        Assert.Equal(MaxCount, results.Count);
    }

    [Fact]
    public async Task GetUserByIdOne()
    {
        XUser? result = await _serviceProvider.GetRequiredService<IUserService>().GetUserByIdAsync(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }
}
