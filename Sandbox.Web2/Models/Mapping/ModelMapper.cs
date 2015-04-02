using Sandbox.Domain.Models;

namespace Sandbox.Web2.Models
{
    public static class ModelMapper
    {
        //note: Manually add extension methods instead of using automapper directly in the
        // controller. This way, unmapped conversions can be detected at compile time.
        //note: If number of model classes gets too large, split this class by entity, area,
        // or conceptual entity group.
        //todo: switch to automapper
        /*
        static ModelMapper()
        {
            Mapper.CreateMap<Person, PersonModel>();
            Mapper.CreateMap<PersonModel, Person>();
        }

        public static PersonModel ToModel(this Person entity)
        {
            return Mapper.Map<Person, PersonModel>(entity);
        }

        public static Person ToEntity(this PersonModel model)
        {
            return Mapper.Map<PersonModel, Person>(model);
        }
        */

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