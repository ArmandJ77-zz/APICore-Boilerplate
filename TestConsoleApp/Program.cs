using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnitOfWork;

namespace TestConsoleApp
{
    class Program
    {
        public static IUnitOfWork uow { get; set; }

        static void Main(string[] args)
        {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
            Console.WriteLine("Press key to start");
            Console.ReadLine();
            uow = new UnitOfWork<BloggingContext>(new BloggingContext());
            Console.WriteLine("Starting multiple persistance");
            var watch = new Stopwatch();
            watch.Start();
            var recordCount = 1000;
            for (int i = 1; i < recordCount; i++)
            {
                var blogA = new Blog
                {
                    Title = "BlogA",
                    Url = "http://qwerty.com/bloga",
                    Posts = new List<Post> {
                        new Post {
                            Title = "How to find qwerty?",
                            Content = "qwerty here it is",
                        }
                    }
                };
                uow.GetRepository<Blog>().Insert(blogA);
                uow.SaveChanges();

            }

            watch.Stop();
            var endTime = watch.Elapsed;
            Console.WriteLine($"Inserted {recordCount} with a total duration of {endTime} averaging {endTime / recordCount}");
            Console.WriteLine("Starting cleanup");
            var foo = uow.GetRepository<Blog>().GetAll();
            foreach (var blog in foo)
            {
                uow.GetRepository<Blog>().Delete(blog);
            }
            uow.SaveChanges();
            Console.WriteLine("Cleanup completed");
            Console.WriteLine("Starting single persistance");
            var watch1 = new Stopwatch();
            watch1.Start();
            for (int i = 1; i < recordCount; i++)
            {
                var blogA = new Blog
                {
                    Title = "BlogA",
                    Url = "http://qwerty.com/bloga",
                    Posts = new List<Post> {
                        new Post {
                            Title = "How to find qwerty?",
                            Content = "qwerty here it is",
                        }
                    }
                };
                uow.GetRepository<Blog>().Insert(blogA);
            }
            uow.SaveChanges();
            watch1.Stop();
            var endTime2 = watch1.Elapsed;
            Console.WriteLine("Starting cleanup");
            var foobar = uow.GetRepository<Blog>().GetAll();
            foreach (var blog in foobar)
            {
                uow.GetRepository<Blog>().Delete(blog);
            }
            uow.SaveChanges();
            Console.WriteLine("Cleanup completed");
            Console.WriteLine($"Inserted {recordCount} with a total duration of {endTime2} averaging {endTime2 / recordCount}");

            Console.ReadLine();
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts);
        }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

}
