using Microsoft.EntityFrameworkCore;
using DbContextEntities.People;

namespace SberbankDbContext
{
    public class SberbankDbContextСonnector : DbContext
    {
        #region DbSets
        public DbSet<ClientEntity> Clients => Set<ClientEntity>();
        #endregion

        public SberbankDbContextСonnector(DbContextOptions<SberbankDbContextСonnector> options) : base(options) { }
    }
}
