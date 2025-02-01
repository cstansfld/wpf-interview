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
    public int UserId
    {
        get => toDo.UserId;
    }

    public int Id
    {
        get => toDo.Id;
    }

    public string Title
    {
        get => toDo.Title;
        set => SetProperty(toDo.Title, value, toDo, (t, n) => t = t with { Title = n });
    }

    public bool Completed
    {
        get => toDo.Completed;
        set => SetProperty(toDo.Completed, value, toDo, (t, n) => t = t with { Completed = n });
    }
}
