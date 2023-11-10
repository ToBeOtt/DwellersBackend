using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Offerings.Domain.DwellerServices;
using Mapster;

namespace Dwellers.Offerings.Mappings.DwellerServices
{
    public class DwellerServicesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DwellerServiceEntity, DwellerService>()
                .Map(dest => dest, src => src);
        }
    }
}
