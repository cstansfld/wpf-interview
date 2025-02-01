using System.Text.Json.Serialization;

namespace Wpf.Interview.Common.ToDos.Http;

/// <summary>
/// todo item
/// </summary>
/// <param name="UserId"></param>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Completed"></param>
public sealed record XToDo(
    [property: JsonPropertyName("userId")] int UserId,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("completed")] bool Completed);

/// <summary>
/// list of todos
/// </summary>
/// <param name="Items">todos list</param>
public sealed record ToDos([property: JsonPropertyName("toDos")] IList<XToDo> Items);
