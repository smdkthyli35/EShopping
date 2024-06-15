using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Basket.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assembly);
            });

            return services;
        }
    }
}
