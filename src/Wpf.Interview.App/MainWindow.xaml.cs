using System.Windows;
using Wpf.Interview.Common;

namespace Wpf.Interview.App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IUserToDoViewModel userToDoViewModel)
    {
        UserToDos = userToDoViewModel;
        InitializeComponent();
        DataContext = UserToDos;
    }

    public IUserToDoViewModel UserToDos
    {
        get;
    }
}