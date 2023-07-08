using Coffee.Order.Application.Services;
using Coffee.Order.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Coffee.Order.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeOrderService, CoffeeOrderService>();

            return services;
        }
    }
}
