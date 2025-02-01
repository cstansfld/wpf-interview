using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Interview.Common.Users;

namespace Wpf.Interview.Models.Users;

/// <summary>
/// wrap the xtodo transfer object with an observable object
/// </summary>
/// <param name="toDo"></param>
public partial class User(XUser user) : ObservableObject, IUser
{
    public int Id => user.Id;

    public string Name => user.Name;

    public string Username => user.Username;

    public string Email => user.Email;

    public Address Address => user.Address;

    public string Phone => user.Phone;

    public string Website => user.Website;

    public Company Company => user.Company;
}

