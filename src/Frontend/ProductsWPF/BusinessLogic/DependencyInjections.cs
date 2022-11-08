using BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddHttpClient();

            return services;
        }
    }
}
