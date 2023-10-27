using Dwellers.Household.Application.Authentication.Commands.RegisterHouse;
using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Chat;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Authentication.Commands.RegisterHouse
{
    public class RegisterHouseCommandHandler : IRequestHandler<RegisterHouseCommand, RegisterHouseResult>
    {

        private readonly ILogger<RegisterHouseCommandHandler> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseCommandRepository _houseCommandRepository;
        private readonly IChatCommandRepository _chatCommandRepository;

        public RegisterHouseCommandHandler(
            ILogger<RegisterHouseCommandHandler> logger,
            IUserQueryRepository userQueryRepository,
            IHouseCommandRepository houseCommandRepository,
            IChatCommandRepository chatCommandRepository)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseCommandRepository = houseCommandRepository;
            _chatCommandRepository = chatCommandRepository;
        }

        public async Task<RegisterHouseResult> Handle(RegisterHouseCommand command, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserByEmail(command.Email);
            if (user == null)
            {
                _logger.LogInformation("No user exist in database");
                throw new UserNotFoundException("Current user not found");
            }

            var house = new House(command.Name, command.Description);
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

            DwellerConversation dwellerConversation = new DwellerConversation(house.Name);
            if(!await _chatCommandRepository.PersistConversation(dwellerConversation))
            {
                _logger.LogInformation("Conversation could not be implemented");
                throw new PersistanceFailedException("Persistance failed");
            }

            HouseConversation houseConversation = new HouseConversation(house, dwellerConversation);
            if (!await _chatCommandRepository.PersistHouseConversation(houseConversation))
            {
                _logger.LogInformation("Conversation could not be linked to household");
                throw new PersistanceFailedException("Persistance failed");
            }

            return new RegisterHouseResult(user, house);
        }
    }
}
