using Microsoft.EntityFrameworkCore;

namespace SberbankDbContext.Extensions
{
    public static class InitializerDb
    {
        public static void Initialize(this SberbankDbContextСonnector context)
        {
            context.Database.Migrate();
        }
    }
}
