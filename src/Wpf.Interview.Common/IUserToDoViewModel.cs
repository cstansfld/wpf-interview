using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Common;

public interface IUserToDoViewModel
{
    int TabIndex { get; set; }

    void GoForward();
    bool CanGoForward();
    void GoBack();
    bool CanGoBack();

    IToDoViewModel ToDoViewModel { get; }
    IUserViewModel UserViewModel { get; }
}
