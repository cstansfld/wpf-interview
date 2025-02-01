using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.ToDos.Http;

namespace Wpf.Interview.Models.ToDos;

/// <summary>
/// wrap the xtodo transfer object with an observable object
/// </summary>
/// <param name="toDo"></param>
public partial class ToDo(XToDo toDo) : ObservableObject, IToDo
{
    public int UserId => toDo.UserId;

    public int Id => toDo.Id;

    public string Title
    {
        get => toDo.Title;
#pragma warning disable S1854 // Unused assignments should be removed
        set => SetProperty(toDo.Title, value, toDo, (t, n) => t = t with { Title = n });
#pragma warning restore S1854 // Unused assignments should be removed
    }

    public bool Completed
    {
        get => toDo.Completed;
#pragma warning disable S1854 // Unused assignments should be removed
        set => SetProperty(toDo.Completed, value, toDo, (t, n) => t = t with { Completed = n });
#pragma warning restore S1854 // Unused assignments should be removed
    }
}
