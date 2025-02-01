using System.Net.Http.Json;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models.Users;

internal class UserService(HttpClient _httpClient) : IUserService
{
    public async ValueTask<IList<XUser>?> GetAllUsersAsync(int startIndex = 0, int limit = 10, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<IList<XUser>?>($"users?_start={startIndex}&_limit={limit}", cancellationToken);
    }

    public async ValueTask<XUser?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<XUser?>($"users/{id}", cancellationToken);
    }
}
