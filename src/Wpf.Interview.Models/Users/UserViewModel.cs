using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models.Users;

public partial class UserViewModel : ObservableObject, IUserViewModel
{
    readonly IUserService _userService;
    public UserViewModel(IUserService userService)
    {
        _userService = userService;
        GetAllUsers = new AsyncRelayCommand(GetAllUsersAsync, CanLoadUsers);
        GetUserById = new AsyncRelayCommand(GetUserByIdAsync, CanGetUserById);
    }

    public Action<Type>? Notify { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GetUserById))]
    private IUser? selectedUser;

    partial void OnSelectedUserChanged(IUser? value)
    {
        Notify?.Invoke(typeof(IUser));
    }


    private ObservableCollection<IUser> Users { get; } = [];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GetAllUsers))]
    private int userCount;

    public IReadOnlyCollection<IUser> ReadOnlyUsers { get => Users; }

    private bool CanLoadUsers() { return UserCount == 0; }

    private async Task GetAllUsersAsync()
    {
        var results = await _userService.GetAllUsersAsync();
        if (results != null)
        {
            foreach (var item in results)
                Users.Add(new User(item));

            UserCount = Users.Count;

            Notify?.Invoke(ReadOnlyUsers.GetType());
        }
    }

    private bool CanGetUserById() { return SelectedUser != null; }

    private async Task GetUserByIdAsync()
    {
        if (SelectedUser != default)
        {
            var result = await _userService.GetUserByIdAsync(SelectedUser.Id);
            if (result != null)
            {
                SelectedUser = new User(result);
            }

            Notify?.Invoke(SelectedUser.GetType());
        }
    }

    public IAsyncRelayCommand GetAllUsers { get; }
    public IAsyncRelayCommand GetUserById { get; }
}
