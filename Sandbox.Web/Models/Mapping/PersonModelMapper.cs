using AutoMapper;
using Sandbox.Domain.Models;

namespace Sandbox.Web.Models.Mapping
{
    public static class PersonModelMapper
    {
        //Convention: Manually add extension methods instead of using AutoMapper directly in
        //  the controller. This ensures unmapped conversions show up at compile time.
        static PersonModelMapper()
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
    }
}