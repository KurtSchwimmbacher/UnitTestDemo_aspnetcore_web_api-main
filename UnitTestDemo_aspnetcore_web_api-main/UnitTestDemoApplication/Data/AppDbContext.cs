using System;
using Microsoft.EntityFrameworkCore;
using UnitTestDemoApplication.Models;

namespace UnitTestDemoApplication.Data;

/// <summary>
/// Database context for the application. Contains a table for todo items.
/// </summary>
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TodoItem> TodoItems { get; set; }
}
