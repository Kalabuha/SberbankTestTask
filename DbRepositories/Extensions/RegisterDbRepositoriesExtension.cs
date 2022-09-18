using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces;

namespace DbRepositories.Extensions
{
    public static class RegisterDbRepositoriesExtension
    {
        public static IServiceCollection RegisterDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientDbRepository>();

            return services;
        }
    }
}
