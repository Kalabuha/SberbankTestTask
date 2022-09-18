using DataModels.People;

namespace ServiceInterfaces
{
    public interface IClientService
    {
        public Task<ClientDataModel?> GetClientDataByIdAsync(int id);
        public Task<List<ClientDataModel>> GetAllClientsDatasAsync();
        public Task AddClientToDbAsync(ClientDataModel? data);
        public Task AddListClientsToDbAsync(ICollection<ClientDataModel> datas);
        public Task EditClientToDbAsync(ClientDataModel? data);
        public Task RemoveClientToDbAsync(int id);
        public Task RemoveClientToDbAsync(ClientDataModel? data);
    }
}
