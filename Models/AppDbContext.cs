using Microsoft.EntityFrameworkCore;

namespace MonApiMSSQL.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Blog> Blogs { get; set; }

    }
}
