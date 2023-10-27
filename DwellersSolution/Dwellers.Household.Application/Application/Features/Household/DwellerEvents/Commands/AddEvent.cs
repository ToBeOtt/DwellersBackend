using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerEvents.Commands
{
    public record AddEventCommand(
        string Title,
        string Desc,
        string EventScope,
        DateTime EventDate,
        string UserId,
        Guid HouseId
        ) : IRequest<AddEventResult>;
    public record AddEventResult(
        bool Success);

    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, AddEventResult>
    {
        private readonly ILogger<AddEventCommandHandler> _logger;
        private readonly IDwellerEventsCommandRepository _eventsCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public AddEventCommandHandler(
            ILogger<AddEventCommandHandler> logger,
            IDwellerEventsCommandRepository eventsCommandRepository,
            IUserQueryRepository userQueryRepository,
            IHouseQueryRepository houseQueryRepository)
        {
            _logger = logger;
            _eventsCommandRepository = eventsCommandRepository;
            _userQueryRepository = userQueryRepository;
            _houseQueryRepository = houseQueryRepository;
        }

        public async Task<AddEventResult> Handle(AddEventCommand cmd, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(cmd.UserId);
            if (user is null)
            {
                _logger.LogInformation("Could not find entity in database");
                throw new EntityNotFoundException("No user found");
            }

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                throw new EntityNotFoundException("No house found");
            }

            var dwellerEvent = new DwellerEvent(cmd);
            dwellerEvent.User = user;
            dwellerEvent.House = house;


            if (!await _eventsCommandRepository.AddEvent(dwellerEvent))
            {
                _logger.LogInformation("Could not persist event to database");
                throw new PersistanceFailedException("Event could not be persisted");
            }

            return new AddEventResult(
                Success: true);


        }
    }
}
