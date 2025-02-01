using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Common.ToDos;

public interface IToDoViewModel
{
    Action<Type>? Notify { get; }

    IToDo? SelectedToDo { get; }
    IUser? SelectedUser { get; set; }

    ObservableCollection<IToDo> ToDos { get; set; }
    IReadOnlyCollection<IToDo> ReadOnlyToDos { get; }

    IAsyncRelayCommand GetAllToDos { get; }
    IAsyncRelayCommand GetToDosByUserId { get; }
    IAsyncRelayCommand GetToDoById { get; }
}
