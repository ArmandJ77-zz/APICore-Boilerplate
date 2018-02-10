using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace API.Infrastructure.ServiceExtensions
{
    public static class EtlContextServiceExtension
    {
        public static IServiceCollection AddEtlContext
            (this IServiceCollection services, string path)
        {
            services.AddDbContext<Repositories.DatabaseContext>(options =>
                options.UseSqlServer(path));

            return services;
        }
    }
}
