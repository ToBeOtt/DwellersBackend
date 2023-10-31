using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.House.Commands.RegisterHouse
{
    public class RegisterHouseCommandHandler : IRequestHandler<RegisterHouseCommand, RegisterHouseResult>
    {

        private readonly ILogger<RegisterHouseCommandHandler> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseCommandRepository _houseCommandRepository;

        public RegisterHouseCommandHandler(
            ILogger<RegisterHouseCommandHandler> logger,
            IUserQueryRepository userQueryRepository,
            IHouseCommandRepository houseCommandRepository)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseCommandRepository = houseCommandRepository;
        }

        public async Task<RegisterHouseResult> Handle(RegisterHouseCommand command)
        {
            var user = await _userQueryRepository.GetUserByEmail(command.Email);
            if (user == null)
            {
                _logger.LogInformation("No user exist in database");
                throw new UserNotFoundException("Current user not found");
            }

            var house = new DwellerHouse(command.Name, command.Description);
            if (!await _houseCommandRepository.AddHouse(house))
            {
                _logger.LogInformation("Could not persist house to database");
                throw new RegisterFailedException("Persistance failed");
            }

            var houseUser = new HouseUser(house, user);
            if (!await _houseCommandRepository.AddHouseUser(houseUser))
            {
                _logger.LogInformation("User attachment to house could not be persisted");
                throw new RegisterFailedException("Persistance failed");
            }

            return new RegisterHouseResult(user, house);
        }
    }
}
