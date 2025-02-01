using Wpf.Interview.Common.ToDos.Http;

namespace Wpf.Interview.Common.ToDos;

public interface IToDoService
{
#pragma warning disable S1075 // URIs should not be hardcoded
    public const string ToDoBaseUri = "https://jsonplaceholder.typicode.com";
#pragma warning restore S1075 // URIs should not be hardcoded

    ValueTask<IList<XToDo>?> GetAllToDosAsync(int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default);

    ValueTask<IList<XToDo>?> GetToDosByUserIdAsync(int userId, int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default);

    ValueTask<XToDo?> GetToDoByIdAsync(int id, CancellationToken cancellationToken = default);
}
