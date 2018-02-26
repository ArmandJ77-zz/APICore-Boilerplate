using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Linq.Expressions;
using System.Reflection;
using UnitOfWork;

namespace Unit.Tests.UnitOfWork.Infrastructure
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }

        private const string IsDeletedProperty = "IsDeleted";
        private static readonly MethodInfo PropertyMethod =
            typeof(EF).GetMethod(nameof(EF.Property),
                BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("test");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType) == true)
                {
                    //Remove shadow property because when you use _dbset.Find it may return tracked
                    //Entities that may have been marked as delted then there is no way to check 
                    //if IsDeleted == true. Ass ISoftDetalable and IsDelted prop to the deletable
                    //Entity
                    //entity.AddProperty(IsDeletedProperty, typeof(bool));

                    modelBuilder
                        .Entity(entity.ClrType)
                        .HasQueryFilter(GetIsDeletedRestriction(entity.ClrType));
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private static LambdaExpression GetIsDeletedRestriction(Type type)
        {
            var parm = Expression.Parameter(type, "it");
            var prop = Expression.Call(PropertyMethod, parm, Expression.Constant(IsDeletedProperty));
            var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parm);
            return lambda;
        }
    }
}
