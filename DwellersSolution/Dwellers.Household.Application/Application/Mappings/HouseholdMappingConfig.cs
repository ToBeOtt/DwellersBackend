using Dwellers.Common.DAL.Models.DwellerEvents;
using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Domain.Entities;
using Mapster;

namespace Dwellers.Household.Application.Mappings
{
    public class HouseholdMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<HouseEntity, DomainHouse>()
                .Map(dest => dest, src => src);
        }
    }
}
