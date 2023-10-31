using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Calendar.Application.Mappings;
using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Calendar.Domain;
using Dwellers.Common.DAL.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Dwellers.Calendar.Application.Services
{
    public class DwellerEventsCommandService
    {

        private readonly ILogger<DwellerEventsCommandService> _logger;
        private readonly IDwellerEventsCommandRepository _eventsCommandRepository;
        private readonly ICommonUserServices _userService;
        private readonly ICommonHouseServices _houseService;
        private readonly CalendarMappingService _mapping;

        public DwellerEventsCommandService(
            ILogger<DwellerEventsCommandService> logger,
            IDwellerEventsCommandRepository eventsCommandRepository,
            ICommonUserServices userService,
            ICommonHouseServices houseService,
            CalendarMappingService mapping)
        {
            _logger = logger;
            _eventsCommandRepository = eventsCommandRepository;
            _userService = userService;
            _houseService = houseService;
            _mapping = mapping;
        }

        public async Task<EventServiceResponse<bool>> CreateAndPersistEvent(AddEventCommand cmd)
        {
            EventServiceResponse<bool> response = new();

            var user = await _userService.GetUserForOtherServicesById(cmd.UserId);
            if (user is null)
            {
                _logger.LogInformation("Could not find entity in database");
                response.IsSuccess = false;
                return response;
            }

            var house = await _houseService.GetHouseForOtherServicesById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                response.IsSuccess = false;
                return response;
            }

            var dwellerEvent = new DomainDwellerEvent(cmd);
            var scopeResult = await dwellerEvent.SetScope(cmd.EventScope);
            if(!scopeResult.IsSuccess)
            {
                _logger.LogInformation(response.ErrorMessage);
                response.IsSuccess = false;
                return response;
            }

            var persistanceEvent = _mapping.MapToPersistence(dwellerEvent);

            if (!await _eventsCommandRepository.AddEvent(persistanceEvent))
            {
                _logger.LogInformation("Could not persist event to database");
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;
            return response;
        }
    }
}