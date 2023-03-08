using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddDbContext(this IServiceCollection services, string connStr)
        {
            services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(connStr));
        }
    }
}
