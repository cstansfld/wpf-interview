using Wpf.Interview.Common.ToDos.Http;

namespace Wpf.Interview.Common.ToDos;

public interface IToDoService
{
    public const string ToDoBaseUri = "https://jsonplaceholder.typicode.com";

    ValueTask<IList<XToDo>?> GetAllToDosAsync(int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default);

    ValueTask<IList<XToDo>?> GetToDosByUserIdAsync(int userId, int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default);

    ValueTask<XToDo?> GetToDoByIdAsync(int id, CancellationToken cancellationToken = default);
}