using JewelryStore.Services.Contracts;
using JewelryStore.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace JewelryStore.Services
{
    public static class ServiceExtension
    {
        public static void AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
