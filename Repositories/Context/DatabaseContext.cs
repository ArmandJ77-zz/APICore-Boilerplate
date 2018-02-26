using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;
using UnitOfWork;

namespace Repositories.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        private const string IsDeletedProperty = "IsDeleted";
        private static readonly MethodInfo PropertyMethod =
            typeof(EF).GetMethod(nameof(EF.Property),
                BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        private static LambdaExpression GetIsDeletedRestriction(Type type)
        {
            var parm = Expression.Parameter(type, "it");
            var prop = Expression.Call(PropertyMethod, parm, Expression.Constant(IsDeletedProperty));
            var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parm);
            return lambda;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType) != true) continue;
                //Remove shadow property because when you use _dbset.Find it may return tracked
                //Entities that may have been marked as delted then there is no way to check 
                //if IsDeleted == true. Ass ISoftDetalable and IsDelted prop to the deletable
                //Entity
                //entity.AddProperty(IsDeletedProperty, typeof(bool));

                modelBuilder
                    .Entity(entity.ClrType)
                    .HasQueryFilter(GetIsDeletedRestriction(entity.ClrType));
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
