using BlogTask.Models;
using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=blogging.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasData(
            new Blog { Id = 1,Name = "property" ,Url = "https://www.apartmenttherapy.com/" },
            new Blog { Id = 2,Name = "food", Url = "https://pinchofyum.com/" }
        );
    }
}
