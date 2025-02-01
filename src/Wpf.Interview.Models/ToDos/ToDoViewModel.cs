using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models.ToDos;

public partial class ToDoViewModel : ObservableObject, IToDoViewModel
{
    readonly IToDoService _toDoService;
    public ToDoViewModel(IToDoService toDoService)
    {
        _toDoService = toDoService;
        GetAllToDos = new AsyncRelayCommand(GetAllToDosAsync);
        GetToDosByUserId = new AsyncRelayCommand(GetToDosByUserIdAsync);
        GetToDoById = new AsyncRelayCommand(GetToDoByIdAsync);
        ToDos = [];
    }

    public Action<Type>? Notify { get; set; }

    [ObservableProperty]
    private IUser? selectedUser;

    partial void OnSelectedUserChanged(IUser? value)
    {
        GetToDosByUserId.Execute(null);
    }

    [ObservableProperty]
    private IToDo? selectedToDo;

    partial void OnSelectedToDoChanged(IToDo? value)
    {
        Notify?.Invoke(typeof(IToDo));
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GetToDosByUserId))] // this change was required
    private ObservableCollection<IToDo> toDos;

    partial void OnToDosChanged(ObservableCollection<IToDo> value)
    {

    }

    public IReadOnlyCollection<IToDo> ReadOnlyToDos { get => ToDos; }

    private async Task GetAllToDosAsync()
    {
        var results = await _toDoService.GetAllToDosAsync();
        if (results != null)
        {
            foreach (var item in results)
                ToDos.Add(new ToDo(item));
        }

        Notify?.Invoke(ReadOnlyToDos.GetType());
    }

    private async Task GetToDosByUserIdAsync()
    {
        if (SelectedUser != default)
        {
            var results = await _toDoService.GetToDosByUserIdAsync(SelectedUser.Id);
            if (results != null)
            {
                ToDos.Clear();
                foreach (var item in results)
                    ToDos.Add(new ToDo(item));
            }
            Notify?.Invoke(ReadOnlyToDos.GetType());
        }
    }

    private async Task GetToDoByIdAsync()
    {
        if (SelectedToDo != default)
        {
            var result = await _toDoService.GetToDoByIdAsync(SelectedToDo.Id);
            if (result != null)
            {
                SelectedToDo = new ToDo(result);
            }

            Notify?.Invoke(SelectedToDo.GetType());
        }
    }

    public IAsyncRelayCommand GetAllToDos { get; }
    public IAsyncRelayCommand GetToDosByUserId { get; }
    public IAsyncRelayCommand GetToDoById { get; }
}
