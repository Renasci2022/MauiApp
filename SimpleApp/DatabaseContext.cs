using Microsoft.EntityFrameworkCore;
using SimpleApp.Models;

namespace SimpleApp.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "YourDatabaseName.db");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }
}
