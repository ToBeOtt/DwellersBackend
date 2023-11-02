using Dwellers.Common.Data.Models.Household;
using Dwellers.Household.Domain.Entities;
using Mapster;

namespace Dwellers.Household.Mappings
{
    public class HouseholdMappingService
    {
        private readonly TypeAdapterConfig _config;
        public HouseholdMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public HouseEntity MapToPersistence(DwellerHouse domainHouse)
        {
            var persistenceHouse = domainHouse.Adapt<HouseEntity>(_config);
            return persistenceHouse;
        }

        public DwellerHouse MapToDomain(HouseEntity persistenceHouse)
        {
            var domainHouse = persistenceHouse.Adapt<DwellerHouse>(_config);
            return domainHouse;
        }
    }
}
