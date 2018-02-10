using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Blog
    {
        public string Name { get; set; }
        public int BlogId { get; set; }
        //public string Url { get; set; }
        //public int ViewCount { get; set; }
    }
}
