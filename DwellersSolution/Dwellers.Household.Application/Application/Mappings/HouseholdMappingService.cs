using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Domain.Entities;
using Mapster;

namespace Dwellers.Household.Application.Mappings
{
    public class HouseholdMappingService
    {
        private readonly TypeAdapterConfig _config;
        public HouseholdMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public HouseEntity MapToPersistence(DomainHouse domainItem)
        {
            var persistenceItem = domainItem.Adapt<HouseEntity>(_config);
            return persistenceItem;
        }

        public DomainHouse MapToDomain(HouseEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DomainHouse>(_config);
            return domainItem;
        }
    }
}
