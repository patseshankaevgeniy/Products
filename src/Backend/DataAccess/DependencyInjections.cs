using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
