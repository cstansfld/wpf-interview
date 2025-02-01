using System.Text.Json.Serialization;

namespace Wpf.Interview.Common.Users;

/// <summary>
/// xuser item
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Username"></param>
/// <param name="Email"></param>
/// <param name="Address"></param>
/// <param name="Phone"></param>
/// <param name="Website"></param>
/// <param name="Company"></param>
public sealed record XUser(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("address")] Address Address,
    [property: JsonPropertyName("phone")] string Phone,
    [property: JsonPropertyName("website")] string Website,
    [property: JsonPropertyName("company")] Company Company);


/// <summary>
/// address item
/// </summary>
/// <param name="Street"></param>
/// <param name="Suite"></param>
/// <param name="City"></param>
/// <param name="Zipcode"></param>
/// <param name="Geo"></param>
public sealed record Address(
    [property: JsonPropertyName("street")] string Street,
    [property: JsonPropertyName("suite")] string Suite,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("zipcode")] string Zipcode,
    [property: JsonPropertyName("geo")] Geo Geo);

/// <summary>
/// geo item
/// </summary>
/// <param name="Lat"></param>
/// <param name="Lng"></param>
public sealed record Geo(
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng);

/// <summary>
/// company
/// </summary>
/// <param name="Name"></param>
/// <param name="CatchPhrase"></param>
/// <param name="Bs"></param>
public sealed record Company(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("catchPhrase")] string CatchPhrase,
    [property: JsonPropertyName("bs")] string Bs);

/// <summary>
/// list of users
/// </summary>
/// <param name="Items">user list</param>
public sealed record Users([property: JsonPropertyName("users")] IList<XUser> Items);



