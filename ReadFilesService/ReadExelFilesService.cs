using ClosedXML.Excel;
using ServiceInterfaces;
using DataModels.People;
using ModelEnums;

namespace ReadFilesService
{
    public class ReadExelFilesService : IReadExelFilesService
    {
        public List<ClientDataModel> ReadExelFile(Stream stream)
        {
            using var workbook = new XLWorkbook(stream);
            var ws = workbook.Worksheet(1);

            int row = 2;

            var clients = new List<ClientDataModel>();
            while (true)
            {
                int clientNumber;
                string name;
                string residence;
                string? placeComesFrom;
                byte gender;
                byte age;

                if (!ws.Cell($"A{row}").TryGetValue(out clientNumber))
                    break;

                if (!ws.Cell($"B{row}").TryGetValue(out name))
                    break;

                if (!ws.Cell($"C{row}").TryGetValue(out residence))
                    break;

                if (!ws.Cell($"D{row}").TryGetValue(out placeComesFrom))
                {
                    //Не обязательный параметр
                    placeComesFrom = null;
                }

                if (!ws.Cell($"E{row}").TryGetValue(out gender))
                    break;

                if (!ws.Cell($"F{row}").TryGetValue(out age))
                    break;

                clients.Add(new ClientDataModel
                {
                    ClientNumber = clientNumber,
                    Name = name,
                    Residence = residence,
                    PlaceComesFrom = placeComesFrom == string.Empty ? null : placeComesFrom,
                    Gender = (Gender)gender,
                    Age = age,
                });

                row++;
            }

            return clients;
        }
    }
}