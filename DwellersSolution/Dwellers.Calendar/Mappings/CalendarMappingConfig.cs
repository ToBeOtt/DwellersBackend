using Dwellers.Calendar.Domain;
using Dwellers.Calendar.Domain.Entites;
using Dwellers.Common.Data.Models.DwellerEvents;
using Mapster;

namespace Dwellers.Calendar.Mappings
{
    public class CalendarMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DwellerEventEntity, DwellerEvent>()
                .Map(dest => dest, src => src);
        }
    }
}
