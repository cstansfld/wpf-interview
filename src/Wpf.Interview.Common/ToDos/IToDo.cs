namespace Wpf.Interview.Common.ToDos;

public interface IToDo
{
    int UserId { get; }
    int Id { get; }
    string Title { get; set; }
    bool Completed { get; set; }
}
