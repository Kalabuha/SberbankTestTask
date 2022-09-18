using ServiceInterfaces;
using RepositoryInterfaces;
using DataModels.People;

namespace DataServices
{
    internal class ClientDataService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientDataService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientDataModel?> GetClientDataByIdAsync(int id)
        {
            var project = await _clientRepository.GetClientAsync(id);

            return project;
        }

        public async Task<List<ClientDataModel>> GetAllClientsDatasAsync()
        {
            var datas = (await _clientRepository.GetAllClientsAsync())
                .ToList();

            return datas;
        }

        public async Task AddClientToDbAsync(ClientDataModel? data)
        {
            if (data != null)
            {
                if (CheckValidClientData(data))
                {
                    await _clientRepository.AddClientAsync(data);
                }
            }
        }

        public async Task AddListClientsToDbAsync(ICollection<ClientDataModel> datas)
        {
            if (datas.Count > 0)
            {
                foreach (var data in datas)
                {
                    if (CheckValidClientData(data))
                    {
                        await _clientRepository.AddClientAsync(data);
                    }
                }
            }
        }

        public async Task EditClientToDbAsync(ClientDataModel? data)
        {
            if (data != null)
            {
                if (CheckValidClientData(data))
                {
                    await _clientRepository.UpdateClientAsync(data);
                }
            }
        }

        public async Task RemoveClientToDbAsync(int id)
        {
            if (id > 0)
            {
                await _clientRepository.DeleteClientAsync(id);
            }
        }

        public async Task RemoveClientToDbAsync(ClientDataModel? data)
        {
            if (data != null)
            {
                await _clientRepository.DeleteClientAsync(data.Id);
            }
        }

        private bool CheckValidClientData(ClientDataModel data)
        {
            if (string.IsNullOrEmpty(data.Name)) return false;
            if (string.IsNullOrEmpty(data.Residence)) return false;
            if (data.Age > 100) return false;

            return true;
        }
    }
}
