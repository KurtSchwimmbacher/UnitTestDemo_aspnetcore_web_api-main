using System;

namespace UnitTestDemoApplication.Models;

/// <summary>
/// Represents a todo item.
/// </summary>
public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
