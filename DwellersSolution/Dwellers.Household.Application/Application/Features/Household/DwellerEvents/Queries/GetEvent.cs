using Dwellers.Common.DAL.Models.DwellerEvents;
using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerEvents.Queries
{
    public record GetEventQuery(
        Guid EventId) : IRequest<GetEventResult>;
    public record GetEventResult(
    DwellerEventEntity Event,
    string EventScope);

    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResult>
    {
        private readonly ILogger<GetEventQueryHandler> _logger;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository;

        public GetEventQueryHandler(
            ILogger<GetEventQueryHandler> logger,
            IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        {
            _logger = logger;
            _dwellerEventsQueryRepository = dwellerEventsQueryRepository;
        }

        public async Task<GetEventResult> Handle(GetEventQuery query, CancellationToken cancellationToken)
        {
            var dwellerEvent = await _dwellerEventsQueryRepository.GetEvent(query.EventId);
            if (dwellerEvent == null)
            {
                _logger.LogInformation("No events found or registered");
                throw new EntityNotFoundException("No events could be found");
            }

            return new GetEventResult(
                Event: dwellerEvent,
                EventScope: dwellerEvent.EventScope.ToString());
        }
    }
}

