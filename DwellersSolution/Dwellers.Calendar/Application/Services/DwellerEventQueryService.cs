using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Calendar.Contracts.Queries;
using Dwellers.Common.DAL.Models.DwellerEvents;
using Dwellers.Common.DAL.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Dwellers.Calendar.Application.Services
{
    public class DwellerEventQueryService
    {
        private readonly ILogger<DwellerEventQueryService> _logger;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository;
        private readonly ICommonHouseServices _houseService;

        public DwellerEventQueryService(
            ILogger<DwellerEventQueryService> logger,
            IDwellerEventsQueryRepository dwellerEventsQueryRepository,
            ICommonHouseServices houseService)
        {
            _logger = logger;
            _dwellerEventsQueryRepository = dwellerEventsQueryRepository;
            _houseService = houseService;
        }
        public async Task<EventServiceResponse<DwellerEventEntity>> FetchEvent
           (GetEventQuery query)
        {
            EventServiceResponse<DwellerEventEntity> response = new();

            var dwellerEvent = await _dwellerEventsQueryRepository.GetEvent(query.EventId);
            if (dwellerEvent == null)
            {
                _logger.LogInformation("No events found or registered");
                response.IsSuccess = false;
                return response;
            }
            response.IsSuccess = true;
            response.Data = dwellerEvent;
            return response;
        }

        public async Task<EventServiceResponse<ICollection<DwellerEventEntity>>> FetchAllEvents
            (Guid houseId)
        {
            EventServiceResponse<ICollection<DwellerEventEntity>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetAllEvents(houseId);
            if (eventList == null)
            {
                _logger.LogInformation("No events found or registered");
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;
            response.Data = eventList;
            return response;
        }

        public async Task<EventServiceResponse<ICollection<DwellerEventEntity>>> FetchUpcomingEvents
            (GetUpcomingEventsQuery query)
        {
            EventServiceResponse<ICollection<DwellerEventEntity>> response = new();

            var eventList = await _dwellerEventsQueryRepository.GetUpcomingEvents(query.HouseId);
            if (eventList == null)
            {
                _logger.LogInformation("No upcoming events can be found.");
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;
            response.Data = eventList;
            return response;
        }
    }
}


