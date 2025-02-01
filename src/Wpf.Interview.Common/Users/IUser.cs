namespace Wpf.Interview.Common.Users;

public interface IUser
{
    int Id { get; }
    string Name { get; }
    string Username { get; }
    string Email { get; }
    Address Address { get; }
    string Phone { get; }
    string Website { get; }
    Company Company { get; }
}
