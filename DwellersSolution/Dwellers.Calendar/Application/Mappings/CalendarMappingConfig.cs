using Dwellers.Calendar.Domain;
using Dwellers.Common.DAL.Models.DwellerEvents;
using Mapster;

namespace Dwellers.Calendar.Application.Mappings
{
    public class CalendarMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DwellerEventEntity, DomainDwellerEvent>()
                .Map(dest => dest, src => src);
        }
    }
}
