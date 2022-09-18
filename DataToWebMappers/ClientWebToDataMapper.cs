using DataModels.People;
using ModelEnums.Extensions;
using WebModels.People;

namespace DataToWebMappers
{
    public static class ClientWebToDataMapper
    {
        public static ClientDataModel ClientWebToData(this ClientWebModel web)
        {
            var data = new ClientDataModel()
            {
                Id = web.Id,
                Name = web.Name,
                //Gender = web.Gender,
                Residence = web.Residence,
                PlaceComesFrom = web.PlaceComesFrom,
                Age = web.Age
            };

            return data;
        }

        public static ClientWebModel ClientDataToWeb(this ClientDataModel data)
        {
            var web = new ClientWebModel()
            {
                Id = data.Id,
                Name = data.Name,
                Gender = data.Gender.ConvertToShortenedString(),
                Residence = data.Residence,
                PlaceComesFrom = data.PlaceComesFrom,
                Age = data.Age,
            };

            return web;
        }
    }
}