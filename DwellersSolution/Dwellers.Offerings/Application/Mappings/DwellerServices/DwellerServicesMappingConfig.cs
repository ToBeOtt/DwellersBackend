using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Offerings.Domain.Entities.DwellerServices;
using Mapster;

namespace Dwellers.Offerings.Application.Mappings.DwellerServices
{
    public class DwellerServicesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DwellerServiceEntity, DomainDwellerService>()
                .Map(dest => dest, src => src);
        }
    }
}
