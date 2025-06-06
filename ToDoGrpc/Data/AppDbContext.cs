﻿using Microsoft.EntityFrameworkCore;
using ToDoGrpc.Models;

namespace ToDoGrpc.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
    public DbSet<ToDoList> ToDoLists => Set<ToDoList>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // options.UseSqlServer(ConnectionS.SqlConStr);
        options.UseSqlite($"Data Source={Path.Combine(AppContext.BaseDirectory, "development.db")}");
    }
}