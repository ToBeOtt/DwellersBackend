using Dwellers.Calendar.Domain;
using Dwellers.Common.DAL.Models.DwellerEvents;
using Mapster;

namespace Dwellers.Calendar.Application.Mappings
{
    public class CalendarMappingService
    {
        private readonly TypeAdapterConfig _config;
        public CalendarMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public DwellerEventEntity MapToPersistence(DomainDwellerEvent domainItem)
        {
            var persistenceItem = domainItem.Adapt<DwellerEventEntity>(_config);
            return persistenceItem;
        }

        public DomainDwellerEvent MapToDomain(DwellerEventEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DomainDwellerEvent>(_config);
            return domainItem;
        }
    }
}
