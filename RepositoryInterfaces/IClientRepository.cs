using DataModels.People;

namespace RepositoryInterfaces
{
    public interface IClientRepository
    {
        public Task<ClientDataModel?> GetClientAsync(int id);
        public Task<ClientDataModel[]> GetAllClientsAsync();
        public Task<int> AddClientAsync(ClientDataModel data);
        public Task<bool> UpdateClientAsync(ClientDataModel data);
        public Task<bool> DeleteClientAsync(int id);
    }
}
