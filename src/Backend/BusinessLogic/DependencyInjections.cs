using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductsService, ProductsService>();

            return services;
        }
    }
}
