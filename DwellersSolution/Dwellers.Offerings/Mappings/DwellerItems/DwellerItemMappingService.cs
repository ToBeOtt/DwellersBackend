using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Offerings.Domain.DwellerItems;
using Mapster;

namespace Dwellers.Offerings.Mappings.DwellerItems
{
    public class DwellerItemMappingService
    {

        private readonly TypeAdapterConfig _config;
        public DwellerItemMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public DwellerItemEntity MapToPersistence(DwellerItem domainItem)
        {
            var persistenceItem = domainItem.Adapt<DwellerItemEntity>(_config);
            return persistenceItem;
        }

        public DwellerItem MapToDomain(DwellerItemEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DwellerItem>(_config);
            return domainItem;
        }
    }
}
