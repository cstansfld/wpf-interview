using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Interview.Common;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models;

public partial class UserToDoViewModel(IToDoViewModel toDoViewModel, IUserViewModel userViewModel) : ObservableObject, IUserToDoViewModel
{
    public IToDoViewModel ToDoViewModel { get; } = toDoViewModel;
    public IUserViewModel UserViewModel { get; } = userViewModel;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GoForwardCommand))]
    [NotifyCanExecuteChangedFor(nameof(GoBackCommand))]
    private int tabIndex;

    [RelayCommand(CanExecute = nameof(CanGoForward))]
    public void GoForward()
    {
        TabIndex++;
    }

    public bool CanGoForward() { return TabIndex <= 0 && UserViewModel.SelectedUser != null; }

    [RelayCommand(CanExecute = nameof(CanGoBack))]
    public void GoBack()
    {
        TabIndex--;
    }

    public bool CanGoBack() { return TabIndex >= 1; }
}
