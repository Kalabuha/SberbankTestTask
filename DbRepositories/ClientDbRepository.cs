using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using SberbankDbContext;
using DbContextEntities.People;
using DataModels.People;
using EntityToDataMappers;

namespace DbRepositories
{
    internal class ClientDbRepository : BaseDbRepository<ClientEntity>, IClientRepository
    {
        public ClientDbRepository(SberbankDbContextСonnector context) : base(context) {}

        public async Task<ClientDataModel?> GetClientAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.ClientEntityToData();
        }

        public async Task<ClientDataModel[]> GetAllClientsAsync()
        {
            var clients = await Context.Clients
                .Select(p => p.ClientEntityToData())
                .ToArrayAsync();

            return clients;
        }

        public async Task<int> AddClientAsync(ClientDataModel data)
        {
            var entity = data.ClientDataToEntity();
            await AddEntityAsync(entity);
            return entity.ClientNumber;
        }

        public async Task<bool> UpdateClientAsync(ClientDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.ClientDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity == null)
            {
                return false;
            }

            await RemoveEntityAsync(entity);
            return true;
        }
    }
}
