using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.Notes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Notes.Commands.AddNoteholder
{
    public class AddNoteholderCommandHandler : IRequestHandler<AddNoteholderCommand, AddNoteholderResult>
    {
        private readonly ILogger<AddNoteholderCommandHandler> _logger;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly INoteCommandRepository _noteCommandRepository;

        public AddNoteholderCommandHandler(
            ILogger<AddNoteholderCommandHandler> logger,
            IHouseQueryRepository houseQueryRepository,
            INoteCommandRepository noteCommandRepository
            )
        {
            _logger = logger;
            _houseQueryRepository = houseQueryRepository;
            _noteCommandRepository = noteCommandRepository;
        }

        public async Task<AddNoteholderResult> Handle(AddNoteholderCommand cmd, CancellationToken cancellationToken)
        {
            var house = await _houseQueryRepository.GetHouseById(cmd.houseID);
            if (house == null)
            {
                _logger.LogInformation("Could not find house");
                throw new EntityNotFoundException("Entity not found");
            }

            var noteholder = new Noteholder(cmd);

            if (!await _noteCommandRepository.AddNoteholder(noteholder))
            {
                _logger.LogInformation("Could not persist noteholder to database");
                throw new PersistanceFailedException("Persistance failed");
            }

            var houseNoteholder = new HouseNoteholder(house, noteholder);
            if (!await _noteCommandRepository.AddHouseNoteholder(houseNoteholder))
            {
                _logger.LogInformation("Could not attach house to note");
                throw new PersistanceFailedException("Persistance failed");
            }

            return new AddNoteholderResult(noteholder);
        }
    }
}
