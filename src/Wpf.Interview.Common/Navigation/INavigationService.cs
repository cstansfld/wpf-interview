using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Common.Navigation;

public interface INavigationService
{
    void Register();
    void OnNotifyPropertyChanged(Type type);
    bool CanGoBack { get; }
    void GoBack();
    bool CanGoForward { get; }
    void GoForward();
    void Navigate<T>(object? args = null);
}
