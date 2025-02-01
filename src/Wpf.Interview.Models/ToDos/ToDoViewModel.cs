using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models.ToDos;

public partial class ToDoViewModel : ObservableObject, IToDoViewModel
{
    private readonly IToDoService _toDoService;
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
        // fixed notify by adding NotifyCanExecuteChangedFor
    }

    public IReadOnlyCollection<IToDo> ReadOnlyToDos => ToDos;

    private async Task GetAllToDosAsync()
    {
        IList<Common.ToDos.Http.XToDo>? results = await _toDoService.GetAllToDosAsync();
        if (results != null)
        {
            foreach (Common.ToDos.Http.XToDo item in results)
            {
                ToDos.Add(new ToDo(item));
            }
        }

        Notify?.Invoke(ReadOnlyToDos.GetType());
    }

    private async Task GetToDosByUserIdAsync()
    {
        if (SelectedUser != default)
        {
            IList<Common.ToDos.Http.XToDo>? results = await _toDoService.GetToDosByUserIdAsync(SelectedUser.Id);
            if (results != null)
            {
                ToDos.Clear();
                foreach (Common.ToDos.Http.XToDo item in results)
                {
                    ToDos.Add(new ToDo(item));
                }
            }
            Notify?.Invoke(ReadOnlyToDos.GetType());
        }
    }

    private async Task GetToDoByIdAsync()
    {
        if (SelectedToDo != default)
        {
            Common.ToDos.Http.XToDo? result = await _toDoService.GetToDoByIdAsync(SelectedToDo.Id);
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
