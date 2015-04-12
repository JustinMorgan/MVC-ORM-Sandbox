using AutoMapper;
using Sandbox.Domain.Models;

namespace Sandbox.Web.Models.Mapping
{
    public static class PlanModelMapper
    {
        //Convention: Manually add extension methods instead of using AutoMapper directly in
        //  the controller. This ensures unmapped conversions show up at compile time.
        static PlanModelMapper()
        {
            Mapper.CreateMap<User, UserModel>();
            Mapper.CreateMap<ContractRateOption, ContractRateOptionModel>();
            Mapper.CreateMap<Plan, PlanModel>()
                  .ForMember(m => m.OptionName2, exp => exp.MapFrom(plan => plan.Code));
        }

        public static PlanModel ToModel(this Plan entity)
        {
            return Mapper.Map<Plan, PlanModel>(entity);
        }

        public static Plan ToEntity(this PlanModel model)
        {
            return Mapper.Map<PlanModel, Plan>(model);
        }
    }
}