using CustomerService.Models.Clients;
using DataModels.People;
using DataToWebMappers;
using Microsoft.AspNetCore.Mvc;
using ModelEnums;
using ModelEnums.Extensions;
using ServiceInterfaces;

namespace CustomerService.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IReadExelFilesService _readExelFilesService;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(
            IClientService clientService,
            IReadExelFilesService readExelFilesService,
            ILogger<ClientsController> logger)
        {
            _clientService = clientService;
            _readExelFilesService = readExelFilesService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadTable(ClientsFileModel fileModel)
        {
            if (fileModel.File != null)
            {
                _logger.LogInformation("Получен файл {FileName} размером {FileSize} и типом содержимого {FileMime}",
                    fileModel.File.FileName, fileModel.File.Length, fileModel.File.ContentType);
                var clients = ReadExelFile(fileModel.File);
                await _clientService.AddListClientsToDbAsync(clients);
                var data = GetClientsViewModelFromFile(clients);
                return Ok(data);
            }
            else
            {
                return NoContent();
            }
        }

        private ClientsViewModel GetClientsViewModelFromFile(List<ClientDataModel> clients)
        {
            //var data = clients.Select(c => c.ClientDataToWeb()).ToArray();
            var totalCount = clients.Count;
            var groups =
                new[] { Gender.Unknown, Gender.Male, Gender.Female }
                .GroupJoin(clients, i => i, o => o.Gender, (i, o) => (gender: i, count: o.Count()));
            var genderSeries = groups
                .Select(p => new GenderSeriesItemModel(
                    p.gender.ConvertToShortenedString(),
                    p.count == 0 ? 0 : ((double)p.count / totalCount) * 100))
                .ToArray();
            var viewModel = new ClientsViewModel(
                clients.Select(c => c.ClientDataToWeb()).ToArray(),
                genderSeries,
                false);

            return viewModel;
        }

        private List<ClientDataModel> ReadExelFile(IFormFile exelFile)
        {
            var result = new List<ClientDataModel>();
            using (var stream = exelFile.OpenReadStream())
            {
                result = _readExelFilesService.ReadExelFile(stream);
            }

            return result;
        }
    }
}
