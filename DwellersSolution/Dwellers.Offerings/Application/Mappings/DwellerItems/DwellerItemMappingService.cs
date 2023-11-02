using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Offerings.Domain.Entities.DwellerItems;
using Mapster;

namespace Dwellers.Offerings.Application.Mappings.DwellerItems
{
    public class DwellerItemMappingService
    {

        private readonly TypeAdapterConfig _config;
        public DwellerItemMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public DwellerItemEntity MapToPersistence(DomainDwellerItem domainItem)
        {
            var persistenceItem = domainItem.Adapt<DwellerItemEntity>(_config);
            return persistenceItem;
        }

        public DomainDwellerItem MapToDomain(DwellerItemEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DomainDwellerItem>(_config);
            return domainItem;
        }
    }
}
