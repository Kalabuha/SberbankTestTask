using DbContextEntities.People;
using DataModels.People;
using ModelEnums.Extensions;

namespace EntityToDataMappers
{
    public static class ClientEntityToDataMapper
    {
        public static ClientDataModel ClientEntityToData(this ClientEntity entity)
        {
            var data = new ClientDataModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Gender = entity.Gender,
                Residence = entity.Residence,
                PlaceComesFrom = entity.PlaceComesFrom,
                Age = entity.Age
            };

            return data;
        }

        public static ClientEntity ClientDataToEntity(this ClientDataModel data, ClientEntity? entity = null)
        {
            entity ??= new ClientEntity();

            entity.Id = data.Id;
            entity.Name = data.Name;
            entity.Gender = data.Gender;
            entity.Residence = data.Residence;
            entity.PlaceComesFrom = data.PlaceComesFrom;
            entity.Age = data.Age;

            return entity;
        }
    }
}