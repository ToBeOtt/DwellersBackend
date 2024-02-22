using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.Common.Application.Interfaces.DwellerEvents;
using Dwellers.DwellersEvents.Domain.Entites;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Commands.DwellerEvents
{
    public class DwellerEventsCommandService
    {

        private readonly ILogger<DwellerEventsCommandService> _logger;
        private readonly IDwellerEventsCommandRepository _eventsCommandRepository;
        private readonly IDwellerQueryRepository _dwellerQueryQueries;
        private readonly IDwellingQueryRepository _dwellingQueryRepository;

        public DwellerEventsCommandService(
            ILogger<DwellerEventsCommandService> logger,
            IDwellerEventsCommandRepository eventsCommandRepository,
            IDwellerQueryRepository dwellerQueryQueries,
            IDwellingQueryRepository dwellingQueryRepository)
        {
            _logger = logger;
            _eventsCommandRepository = eventsCommandRepository;
            _dwellerQueryQueries = dwellerQueryQueries;
            _dwellingQueryRepository = dwellingQueryRepository;
        }

        public async Task<DwellerResponse<bool>> CreateAndPersistEvent(AddEventCommand cmd)
        {
            DwellerResponse<bool> response = new();
            var dwelling = await _dwellingQueryRepository.GetDwellingById(cmd.DwellingId);
            var dweller = await _dwellerQueryQueries.GetDwellerByIdAsync(cmd.DwellerId);

            var dwellerEvent = new DwellerEvent(cmd.Title, cmd.Desc, dwelling, dweller);
            await dwellerEvent.SetScopeFromUI(cmd.EventScope);

            var scopeResult = await dwellerEvent.SetScopeFromUI(cmd.EventScope);
            if (!scopeResult.IsSuccess)
                return await response.ErrorResponse
                         (response.ErrorMessage);


            if (!await _eventsCommandRepository.AddEvent(dwellerEvent))
                return await response.ErrorResponse
                     ("Server-error");

            return await response.SuccessResponse();
        }
    }
}