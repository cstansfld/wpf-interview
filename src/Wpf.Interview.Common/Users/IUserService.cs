namespace Wpf.Interview.Common.Users;

public interface IUserService
{
#pragma warning disable S1075 // URIs should not be hardcoded
    public const string UserBaseUri = "https://jsonplaceholder.typicode.com";
#pragma warning restore S1075 // URIs should not be hardcoded

    ValueTask<IList<XUser>?> GetAllUsersAsync(int startIndex = 0, int limit = 10, CancellationToken cancellationToken = default);

    ValueTask<XUser?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
}
