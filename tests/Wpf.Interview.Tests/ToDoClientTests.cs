using Microsoft.Extensions.DependencyInjection;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Models.Logging;
using Wpf.Interview.Models.ToDos.Register;

namespace Wpf.Interview.Tests;

public class ToDoClientTests
{
    private readonly ServiceProvider _serviceProvider;
    public ToDoClientTests()
    {
        var services = new ServiceCollection();
        services.RegisterLogging()
            .RegisterToDoHttpClient();
        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetAllToDos()
    {
        const int MaxCount = 20;
        // default startIndex = 0, limit is 20
        IList<Common.ToDos.Http.XToDo>? results = await _serviceProvider.GetRequiredService<IToDoService>().GetAllToDosAsync();
        Assert.NotNull(results);
        Assert.Equal(MaxCount, results.Count);
    }

    [Fact]
    public async Task GetAllToDosTestPaging()
    {
        const int MaxCount = 10;
        const int StartIndex = 0;
        // default startIndex = 0, limit is 10
        IList<Common.ToDos.Http.XToDo>? results = await _serviceProvider.GetRequiredService<IToDoService>().GetAllToDosAsync(StartIndex, MaxCount);
        Assert.NotNull(results);
        Assert.Equal(MaxCount, results.Count);
    }

    [Fact]
    public async Task GetToDosByUserIdOne()
    {
        IList<Common.ToDos.Http.XToDo>? results = await _serviceProvider.GetRequiredService<IToDoService>().GetToDosByUserIdAsync(1);
        Assert.NotNull(results);
        Assert.NotEmpty(results);
    }

    [Fact]
    public async Task GetToDoByIdOne()
    {
        Common.ToDos.Http.XToDo? result = await _serviceProvider.GetRequiredService<IToDoService>().GetToDoByIdAsync(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.UserId);
    }
}
