using Dwellers.Calendar.Domain;
using Dwellers.Calendar.Domain.Entites;
using Dwellers.Common.Data.Models.DwellerEvents;
using Mapster;

namespace Dwellers.Calendar.Mappings
{
    public class CalendarMappingService
    {
        private readonly TypeAdapterConfig _config;
        public CalendarMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public DwellerEventEntity MapToPersistence(DwellerEvent domainItem)
        {
            var persistenceItem = domainItem.Adapt<DwellerEventEntity>(_config);
            return persistenceItem;
        }

        public DwellerEvent MapToDomain(DwellerEventEntity persistenceItem)
        {
            var domainItem = persistenceItem.Adapt<DwellerEvent>(_config);
            return domainItem;
        }
    }
}
