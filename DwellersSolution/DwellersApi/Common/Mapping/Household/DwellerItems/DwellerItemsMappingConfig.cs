using Dwellers.Household.Application.Features.Household.DwellerEvents.Queries;
using Dwellers.Household.Application.Features.Household.DwellerItems.Commands;
using Dwellers.Household.Application.Features.Household.DwellerItems.Queries;
using Dwellers.Household.Contracts.Requests.Household.DwellerItems;
using Dwellers.Household.Contracts.Responses.Household.DwellerEvents;
using Dwellers.Household.Contracts.Responses.Household.DwellerItems;
using Mapster;

namespace DwellersApi.Common.Mapping.Household.DwellerItems
{
    public class DwellerItemsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<AddDwellerItemRequest, AddDwellerItemCommand>();
            config.NewConfig<RemoveDwellerItemRequest, RemoveDwellerItemCommand>();

            // Result => Response
            config.NewConfig<AddDwellerItemResult, AddDwellerItemResponse>()
                .Map(dest => dest, src => src);

            config.NewConfig<GetDwellerItemResult, GetDwellerItemResponse>()
                .Map(dest => dest, src => src.DwellerItem);

            config.NewConfig<GetAllDwellerItemsResult, GetAllDwellerItemsResponse>()
                .Map(dest => dest, src => src);

            config.NewConfig<GetAllEventsResult, GetAllEventsResponse>()
                .Map(dest => dest, src => src);

            config.NewConfig<GetUpcomingEventsResult, GetUpcomingEventsResponse>()
                .Map(dest => dest, src => src);
        }
    }
}
