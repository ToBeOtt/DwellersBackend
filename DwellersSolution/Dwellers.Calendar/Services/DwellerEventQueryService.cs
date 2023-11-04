using Dwellers.Calendar.Contracts.Queries;
using Dwellers.Common.Data.Models.DwellerEvents;
using Dwellers.Common.Persistance.CalendarModule.Interfaces;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

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
        public async Task<ServiceResponse<DwellerEventEntity>> FetchEvent
           (GetEventQuery query)
        {
            ServiceResponse<DwellerEventEntity> response = new();

            var dwellerEvent = await _dwellerEventsQueryRepository.GetEvent(query.EventId);
            if (dwellerEvent == null)
                return await response.ErrorResponse
                        (response, "No events found or registered.", _logger);

            return await response.SuccessResponse(response, dwellerEvent);
        }

        public async Task<ServiceResponse<ICollection<DwellerEventEntity>>> FetchAllEvents
            (Guid houseId)
        {
            ServiceResponse<ICollection<DwellerEventEntity>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetAllEvents(houseId);
            if (eventList == null)
                return await response.ErrorResponse
                           (response, "No events found or registered.", _logger);

            return await response.SuccessResponse(response, eventList);
        }

        public async Task<ServiceResponse<ICollection<DwellerEventEntity>>> FetchUpcomingEvents
            (GetUpcomingEventsQuery query)
        {
            ServiceResponse<ICollection<DwellerEventEntity>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetUpcomingEvents(query.HouseId);
            if (eventList == null)
                return await response.ErrorResponse
                        (response, "No upcoming events can be found.", _logger);
        
           return await response.SuccessResponse(response, eventList);;
        }
    }
}


