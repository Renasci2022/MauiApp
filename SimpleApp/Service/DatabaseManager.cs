using Microsoft.EntityFrameworkCore;
using SimpleApp.Models;

namespace SimpleApp.Data;

public class DatabaseManager
{
    private readonly DatabaseContext _dbContext;

    public DatabaseManager()
    {
        _dbContext = new DatabaseContext();

        _dbContext.Database.EnsureCreated();
    }

    public List<Post> GetPosts()
    {
        return _dbContext.Posts.ToList();
    }

    public void AddPost(Post post)
    {
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();
    }
}
