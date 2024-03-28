using Microsoft.EntityFrameworkCore;
using SimpleApp.Models;

namespace SimpleApp.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MauiAppDatabase.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath) ?? throw new InvalidOperationException("The database directory cannot be null."));
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }
}
