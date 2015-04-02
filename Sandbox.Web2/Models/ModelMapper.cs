using Sandbox.Domain.Models;

namespace Sandbox.Web2.Models
{
    public static class ModelMapper
    {
        public static PersonModel ToModel(this Person entity)
        {
            return new PersonModel()
            {
                Id = entity.Id,
                BirthDate = entity.BirthDate,
                Name = entity.Name
            };
        }

        public static Person ToEntity(this PersonModel model)
        {
            return new Person()
            {
                Id = model.Id,
                BirthDate = model.BirthDate,
                Name = model.Name
            };
        }
    }
}