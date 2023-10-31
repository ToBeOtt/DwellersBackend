using Dwellers.Household.Application.Features.House.Commands.RegisterHouse;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.House.Commands.RegisterMemberToHouse
{
    public class RegisterMemberToHouseCommandHandler : IRequestHandler<RegisterMemberToHouseCommand, RegisterMemberToHouseResult>
    {
        private readonly ILogger<RegisterMemberToHouseCommandHandler> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseCommandRepository _houseCommandRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public RegisterMemberToHouseCommandHandler(
            ILogger<RegisterMemberToHouseCommandHandler> logger,
            IUserQueryRepository userQueryRepository,
            IHouseCommandRepository houseCommandRepository,
            IHouseQueryRepository houseQueryRepository)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseCommandRepository = houseCommandRepository;
            _houseQueryRepository = houseQueryRepository;
        }
        public async Task<RegisterMemberToHouseResult> Handle(RegisterMemberToHouseCommand command, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserByEmail(command.Email);
            if (user is null)
            {
                _logger.LogInformation("No user exist in database");
                throw new UserNotFoundException("Current user not found");
            }

            var house = await _houseQueryRepository.GetHouseByInvite(command.Invitation);
            if (house is null)
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

            (registerHouseResult.House.HouseId,
                 registerHouseResult.House.Name);
            return new RegisterMemberToHouseResult(user, house);
        }
    }
}
