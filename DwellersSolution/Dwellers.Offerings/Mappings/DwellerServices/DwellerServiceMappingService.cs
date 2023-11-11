using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Offerings.Domain.DwellerServices;
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

        public DwellerServiceEntity MapToPersistence(DwellerService domainItem)
        {
            var persistenceItem = domainItem.Adapt<DwellerServiceEntity>(_config);
            return persistenceItem;
        }

        public DwellerService MapToDomain(DwellerServiceEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DwellerService>(_config);
            return domainItem;
        }
    }
}
