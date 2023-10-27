using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerEvents.Queries
{
    public record GetUpcomingEventsQuery(
        Guid HouseId) : IRequest<GetUpcomingEventsResult>;
    public record GetUpcomingEventsResult(
         ICollection<DwellerEvent> UpcomingEvents);

    public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, GetUpcomingEventsResult>
    {
        private readonly ILogger<GetUpcomingEventsQueryHandler> _logger;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository;

        public GetUpcomingEventsQueryHandler(
            ILogger<GetUpcomingEventsQueryHandler> logger,
            IHouseQueryRepository houseQueryRepository,
            IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        {
            _logger = logger;
            _houseQueryRepository = houseQueryRepository;
            _dwellerEventsQueryRepository = dwellerEventsQueryRepository;
        }

        public async Task<GetUpcomingEventsResult> Handle(GetUpcomingEventsQuery query, CancellationToken cancellationToken)
        {
            var eventList = await _dwellerEventsQueryRepository.GetUpcomingEvents(query.HouseId);
            if (eventList == null)
            {
                _logger.LogInformation("No upcoming events can be found.");
                throw new EntityNotFoundException("No events could be found.");
            }

            return new GetUpcomingEventsResult(
                UpcomingEvents: eventList);

        }
    }
}
