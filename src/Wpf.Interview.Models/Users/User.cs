using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models.Users;

/// <summary>
/// wrap the xtodo transfer object with an observable object
/// </summary>
/// <param name="toDo"></param>
public partial class User(XUser user) : ObservableObject, IUser
{
    public int Id
    {
        get => user.Id;
    }

    public string Name
    {
        get => user.Name;
    }

    public string Username
    {
        get => user.Username;
    }

    public string Email
    {
        get => user.Email;
    }

    public Address Address
    {
        get => user.Address;
    }

    public string Phone
    {
        get => user.Phone;
    }

    public string Website
    {
        get => user.Website;
    }

    public Company Company
    {
        get => user.Company;
    }
}

