using Catalog.API.Data.Repositories;
using Catalog.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
