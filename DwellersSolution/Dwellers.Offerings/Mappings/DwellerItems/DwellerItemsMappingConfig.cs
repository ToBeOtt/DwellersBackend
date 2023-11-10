using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Offerings.Domain.DwellerItems;
using Mapster;

namespace Dwellers.Offerings.Mappings.DwellerItems
{
    public class DwellerItemsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DwellerItemEntity, DwellerItem>()
                .Map(dest => dest, src => src);
        }
    }
}
