using Microsoft.EntityFrameworkCore;
using Unit.Tests.UnitOfWork.Entities;

namespace Unit.Tests.UnitOfWork.Infrastructure
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("test");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts);
        }
    }
}
