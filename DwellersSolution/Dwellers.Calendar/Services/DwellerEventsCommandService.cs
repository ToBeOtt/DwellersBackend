using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Calendar.Domain.Entites;
using Dwellers.Calendar.Mappings;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Microsoft.Extensions.Logging;

namespace Dwellers.Calendar.Services
{
    public class DwellerEventsCommandService
    {

        private readonly ILogger<DwellerEventsCommandService> _logger;
        private readonly IDwellerEventsCommandRepository _eventsCommandRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly CalendarMappingService _mapping;

        public DwellerEventsCommandService(
            ILogger<DwellerEventsCommandService> logger,
            IDwellerEventsCommandRepository eventsCommandRepository,
            IHouseQueryRepository houseQueryRepository,
            IUserQueryRepository userQueryRepository,
            CalendarMappingService mapping)
        {
            _logger = logger;
            _eventsCommandRepository = eventsCommandRepository;
            _houseQueryRepository = houseQueryRepository;
            _userQueryRepository = userQueryRepository;
            _mapping = mapping;
        }

        public async Task<EventServiceResponse<bool>> CreateAndPersistEvent(AddEventCommand cmd)
        {
            EventServiceResponse<bool> response = new();

            var user = await _userQueryRepository.GetUserById(cmd.UserId);
            if (user is null)
            {
                _logger.LogInformation("Could not find entity in database");
                response.IsSuccess = false;
                return response;
            }

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                response.IsSuccess = false;
                return response;
            }

            var dwellerEvent = new DwellerEvent(cmd);
            var scopeResult = await dwellerEvent.SetScopeFromUI(cmd.EventScope);
            if (!scopeResult.IsSuccess)
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