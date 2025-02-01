using System.Net.Http.Json;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.ToDos.Http;

namespace Wpf.Interview.Models.ToDos;

internal class ToDoService(HttpClient _httpClient) : IToDoService
{
    public async ValueTask<IList<XToDo>?> GetAllToDosAsync(int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<IList<XToDo>>($"todos?_start={startIndex}&_limit={limit}", cancellationToken);
    }

    public async ValueTask<XToDo?> GetToDoByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<XToDo>($"todos/{id}", cancellationToken);
    }

    public async ValueTask<IList<XToDo>?> GetToDosByUserIdAsync(int userId, int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<IList<XToDo>?>($"users/{userId}/todos?_start={startIndex}&_limit={limit}", cancellationToken);
    }
}
