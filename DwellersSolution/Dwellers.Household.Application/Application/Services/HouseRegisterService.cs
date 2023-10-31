using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Application.Features.House.Commands.RegisterMemberToHouse;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Application.Mappings;
using Dwellers.Household.Application.Services.Responses;
using Dwellers.Household.Contracts.Commands;
using Dwellers.Household.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Services
{
    public class HouseRegisterService
    {

        private readonly ILogger<HouseRegisterService> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseCommandRepository _houseCommandRepository;
        private readonly HouseholdMappingService _mapping;

        public HouseRegisterService(
            ILogger<HouseRegisterService> logger,
            IUserQueryRepository userQueryRepository,
            IHouseCommandRepository houseCommandRepository,
            HouseholdMappingService mapping)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseCommandRepository = houseCommandRepository;
            _mapping = mapping;
        }

        public async Task<HouseRegisterResponse> Handle(RegisterHouseCommand command)
        {
            HouseRegisterResponse response = new();
            var user = await _userQueryRepository.GetUserByEmail(command.Email);
            if (user == null)
            {
                _logger.LogInformation("No user exist in database");
                response.IsSuccess = false;
                return response;
            }

            var domainHouse = new DomainHouse(command.Name, command.Description);

            var persistanceHouse = _mapping.MapToPersistence(domainHouse);

            if (!await _houseCommandRepository.AddHouse(persistanceHouse))
            {
                _logger.LogInformation("Could not persist house to database");
                response.IsSuccess = false;
                return response;
            }

            var houseUser = new HouseUserEntity(persistanceHouse, user);
            if (!await _houseCommandRepository.AddHouseUser(houseUser))
            {
                _logger.LogInformation("User attachment to house could not be persisted");
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;
            response.Name = domainHouse.Name;
            response.HouseId = domainHouse.Id;
            return response;
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
            return new RegisterMemberToHouseResult(user, house);
        }
    }
}
