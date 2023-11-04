using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Offerings.Domain.Entities.DwellerServices;
using Mapster;

namespace Dwellers.Offerings.Mappings.DwellerServices
{
    public class DwellerServiceMappingService
    {
        private readonly TypeAdapterConfig _config;
        public DwellerServiceMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public DwellerServiceEntity MapToPersistence(DomainDwellerService domainItem)
        {
            var persistenceItem = domainItem.Adapt<DwellerServiceEntity>(_config);
            return persistenceItem;
        }

        public DomainDwellerService MapToDomain(DwellerServiceEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DomainDwellerService>(_config);
            return domainItem;
        }
    }
}
