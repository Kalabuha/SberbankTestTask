using DataModels.People;

namespace ServiceInterfaces
{
    public interface IReadExelFilesService
    {
        public List<ClientDataModel> ReadExelFile(Stream stream);

    }
}
