using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Offerings.Domain.Entities.DwellerItems;
using Mapster;

namespace Dwellers.Offerings.Mappings.DwellerItems
{
    public class DwellerItemsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DwellerItemEntity, DomainDwellerItem>()
                .Map(dest => dest, src => src);
        }
    }
}
