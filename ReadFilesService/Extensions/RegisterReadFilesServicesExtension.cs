using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace ReadFilesService.Extensions
{
    public static class RegisterReadFilesServicesExtension
    {
        public static IServiceCollection RegisterReadExelFilesService(this IServiceCollection services)
        {
            services.AddScoped<IReadExelFilesService, ReadExelFilesService>();

            return services;
        }
    }
}
