using JewelryStore.DataLayer.Repositories.Contracts;
using JewelryStore.DataLayer.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JewelryStore.DataLayer
{
    public static class ServiceExtension
    {
        public static void AddDataLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JewelryStoreDbContext>(opts => opts.UseSqlServer(configuration["ConnectionStrings:JewelryShop"]));

            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}