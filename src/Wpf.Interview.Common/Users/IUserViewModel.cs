using CommunityToolkit.Mvvm.Input;

namespace Wpf.Interview.Common.Users;

public interface IUserViewModel
{
    Action<Type>? Notify { get; }

    IUser? SelectedUser { get; }

    IReadOnlyCollection<IUser> ReadOnlyUsers { get; }

    IAsyncRelayCommand GetAllUsers { get; }
    IAsyncRelayCommand GetUserById { get; }
}
