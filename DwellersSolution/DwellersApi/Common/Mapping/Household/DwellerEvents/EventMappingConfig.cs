using Dwellers.Household.Application.Features.Household.DwellerEvents.Commands;
using Dwellers.Household.Application.Features.Household.DwellerEvents.Queries;
using Dwellers.Household.Contracts.Requests.Household.DwellerEvents;
using Dwellers.Household.Contracts.Responses.Household.DwellerEvents;
using Mapster;

namespace DwellersApi.Common.Mapping.Household.DwellerEvents
{
    public class DwellerEventMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<AddEventRequest, AddEventCommand>();
            config.NewConfig<GetAllEventsRequest, GetAllEventsQuery>();
            config.NewConfig<GetUpcomingEventsRequest, GetUpcomingEventsQuery>();

            // Result => Response
            config.NewConfig<AddEventResult, AddEventResponse>()
                .Map(dest => dest, src => src);

            config.NewConfig<GetEventResult, GetEventResponse>()
                 .Map(dest => dest.Event, src => src.Event)
                 .Map(dest => dest.EventScope, src => src.EventScope);

            config.NewConfig<GetAllEventsResult, GetAllEventsResponse>()
                .Map(dest => dest, src => src);

            config.NewConfig<GetUpcomingEventsResult, GetUpcomingEventsResponse>()
                .Map(dest => dest, src => src);
        }
    }
}
