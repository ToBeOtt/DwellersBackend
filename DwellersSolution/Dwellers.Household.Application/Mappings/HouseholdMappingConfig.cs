using Dwellers.Common.Data.Models.Household;
using Dwellers.Household.Domain.Entities;
using Mapster;

namespace Dwellers.Household.Mappings
{
    public class HouseholdMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<HouseEntity, DwellerHouse>()
                .Map(dest => dest, src => src);
        }
    }
}
