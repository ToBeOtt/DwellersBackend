using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerEvents.Queries
{
    public record GetAllEventsQuery(
        Guid HouseId) : IRequest<GetAllEventsResult>;
    public record GetAllEventsResult(
        ICollection<DwellerEvent> AllEvents);

    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, GetAllEventsResult>
    {
        private readonly ILogger<GetAllEventsQueryHandler> _logger;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly IDwellerEventsQueryRepository _dwellerEventsQueryRepository;

        public GetAllEventsQueryHandler(
            ILogger<GetAllEventsQueryHandler> logger,
            IHouseQueryRepository houseQueryRepository,
            IDwellerEventsQueryRepository dwellerEventsQueryRepository)
        {
            _logger = logger;
            _houseQueryRepository = houseQueryRepository;
            _dwellerEventsQueryRepository = dwellerEventsQueryRepository;
        }

        public async Task<GetAllEventsResult> Handle(GetAllEventsQuery query, CancellationToken cancellationToken)
        {
            var eventList = await _dwellerEventsQueryRepository.GetAllEvents(query.HouseId);
            if (eventList == null)
            {
                _logger.LogInformation("No events found or registered");
                throw new EntityNotFoundException("No events could be found");
            }

            return new GetAllEventsResult(
                AllEvents: eventList);
        }
    }
}
