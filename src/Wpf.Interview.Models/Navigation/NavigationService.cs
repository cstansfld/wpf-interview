using System.Collections.ObjectModel;
using Wpf.Interview.Common;
using Wpf.Interview.Common.Navigation;
using Wpf.Interview.Common.ToDos;
using Wpf.Interview.Common.Users;
using Wpf.Interview.Models.ToDos;
using Wpf.Interview.Models.Users;

namespace Wpf.Interview.Models.Navigation;

/// <summary>
/// just for nav this would need alot of intelligence
/// </summary>
/// <param name="_userToDoViewModel"></param>
public class NavigationService(IUserToDoViewModel _userToDoViewModel) : INavigationService
{
    //commented because this needs to be expanded upon
    // private readonly Dictionary<Type, Type> viewMapping = new()
    //{
    //    [typeof(MainPageViewModel)] = typeof(MainPage),
    //    // Other viewmodel types...
    //};

    public void Register()
    {
        ((UserViewModel)_userToDoViewModel.UserViewModel).Notify = OnNotifyPropertyChanged;
        ((ToDoViewModel)_userToDoViewModel.ToDoViewModel).Notify = OnNotifyPropertyChanged;
    }

    public bool CanGoBack => _userToDoViewModel.CanGoBack();

    public bool CanGoForward => _userToDoViewModel.CanGoForward();

    public void GoBack() => _userToDoViewModel.GoBack();

    public void GoForward() => _userToDoViewModel.GoForward();

    /// <summary>
    /// review this with alternate design patterns for Page and ViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args"></param>
    public void Navigate<T>(object? args)
    {
        //this.frame.Navigate(this.viewMapping[typeof(T)], args);
    }

    // this need PropertyName and type and source ViewModel
    public void OnNotifyPropertyChanged(Type type)
    {
        if (type == typeof(ObservableCollection<IUser>))
        {
            // This tells me I have loaded users
        }
        else if (typeof(IUser).IsAssignableFrom(type))
        {
            // manual intervention required here... need to review interactions
            // This tells me the Selected User has been invoked
            // Go Forward
            _userToDoViewModel.ToDoViewModel.SelectedUser = _userToDoViewModel.UserViewModel.SelectedUser;
            _userToDoViewModel.GoForward();
        }
        else if (type == typeof(ObservableCollection<IToDo>))
        {
            // This tells me I have loaded todos
        }
        else if (typeof(IToDo).IsAssignableFrom(type))
        {
            // This tells me the Selected IToDo has been invoked      
        }
        else
        {
            // Handle other types
        }
    }
}
