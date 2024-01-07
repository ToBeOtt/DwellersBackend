using Dwellers.Calendar.Contracts.Queries;
using Dwellers.Common.Data.Models.DwellerEvents;
using Dwellers.Common.Persistance.CalendarModule.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Calendar.Services
{
    public class DwellerEventQueryService
    {
        private readonly ILogger<DwellerEventQueryService> _logger;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository;

        public DwellerEventQueryService(
            ILogger<DwellerEventQueryService> logger,
            IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        {
            _logger = logger;
            _dwellerEventsQueryRepository = dwellerEventsQueryRepository;
        }
        public async Task<DwellerResponse<DwellerEventEntity>> FetchEvent
           (GetEventQuery query)
        {
            DwellerResponse<DwellerEventEntity> response = new();

            var dwellerEvent = await _dwellerEventsQueryRepository.GetEvent(query.EventId);
            if (dwellerEvent == null)
                return await response.ErrorResponse
                        ("No events found or registered.");

            return await response.SuccessResponse(dwellerEvent);
        }

        public async Task<DwellerResponse<ICollection<DwellerEventEntity>>> FetchAllEvents
            (Guid houseId)
        {
            DwellerResponse<ICollection<DwellerEventEntity>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetAllEvents(houseId);
            if (eventList == null)
                return await response.ErrorResponse
                           ("No events found or registered.");

            return await response.SuccessResponse(eventList);
        }

        public async Task<DwellerResponse<ICollection<DwellerEventEntity>>> FetchUpcomingEvents
            (GetUpcomingEventsQuery query)
        {
            DwellerResponse<ICollection<DwellerEventEntity>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetUpcomingEvents(query.HouseId);
            if (eventList == null)
                return await response.ErrorResponse
                        ("No upcoming events can be found.");
        
           return await response.SuccessResponse(eventList);;
        }
    }
}


