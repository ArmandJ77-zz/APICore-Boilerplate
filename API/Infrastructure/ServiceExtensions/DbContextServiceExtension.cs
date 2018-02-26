using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Context;

namespace API.Infrastructure.ServiceExtensions
{
    public static class DbContextServiceExtension
    {
        public static IServiceCollection AddDbContext
            (this IServiceCollection services, string path)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(path));

            return services;
        }
    }
}
