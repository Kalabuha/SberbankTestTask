using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SberbankDbContext.Extensions
{
    public static class RegisterDbContextExtension
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SberbankDbContextСonnector>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
