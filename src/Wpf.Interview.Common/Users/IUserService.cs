namespace Wpf.Interview.Common.Users;

public interface IUserService
{
    public const string UserBaseUri = "https://jsonplaceholder.typicode.com";

    ValueTask<IList<XUser>?> GetAllUsersAsync(int startIndex = 0, int limit = 20, CancellationToken cancellationToken = default);

    ValueTask<XUser?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
}
