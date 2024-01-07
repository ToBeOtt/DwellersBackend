using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Calendar.Domain.Entites;
using Dwellers.Calendar.Mappings;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Calendar.Services
{
    public class DwellerEventsCommandService
    {

        private readonly ILogger<DwellerEventsCommandService> _logger;
        private readonly IDwellerEventsCommandRepository _eventsCommandRepository;
        private readonly CalendarMappingService _mapping;

        public DwellerEventsCommandService(
            ILogger<DwellerEventsCommandService> logger,
            IDwellerEventsCommandRepository eventsCommandRepository,
            CalendarMappingService mapping)
        {
            _logger = logger;
            _eventsCommandRepository = eventsCommandRepository;
            _mapping = mapping;
        }

        public async Task<DwellerResponse<bool>> CreateAndPersistEvent(AddEventCommand cmd)
        {
            DwellerResponse<bool> response = new();

            var dwellerEvent = new DwellerEvent(cmd);
            var scopeResult = await dwellerEvent.SetScopeFromUI(cmd.EventScope);
            if (!scopeResult.IsSuccess)
                return await response.ErrorResponse
                         (response.ErrorMessage);

            var persistanceEvent = _mapping.MapToPersistence(dwellerEvent);

            if (!await _eventsCommandRepository.AddEvent(persistanceEvent))
                return await response.ErrorResponse
                     ("Server-error");

            return await response.SuccessResponse();
        }
    }
}