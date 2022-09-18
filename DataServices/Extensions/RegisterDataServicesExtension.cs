using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace DataServices.Extensions
{
    public static class RegisterDataServicesExtension
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientDataService>();

            return services;
        }
    }
}
