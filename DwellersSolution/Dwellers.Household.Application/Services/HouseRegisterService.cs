using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Dwellers.Household.Contracts.Commands;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Mappings;
using Dwellers.Household.Services.DTO;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Household.Services
{
    public class HouseRegisterService
    {

        private readonly ILogger<HouseRegisterService> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseCommandRepository _houseCommand;
        private readonly IHouseQueryRepository _houseQuery;
        private readonly HouseholdMappingService _mapping;

        public HouseRegisterService(
            ILogger<HouseRegisterService> logger,
            IUserQueryRepository userQueryRepository,
            IHouseCommandRepository houseCommand,
            IHouseQueryRepository houseQuery,
            HouseholdMappingService mapping)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseCommand = houseCommand;
            _houseQuery = houseQuery;
            _mapping = mapping;
        }

        public async Task<ServiceResponse<HouseToUserDTO>> AttachHouseToUser(RegisterHouseCommand cmd)
        {
            ServiceResponse<HouseToUserDTO> response = new();
            var domainHouse = new DwellerHouse();

            var user = await _userQueryRepository.GetUserByEmail(cmd.Email);
            if (user == null)
               return await response.ErrorResponse(response, "User not found", _logger, "gfd");


            var nameResult = domainHouse.SetName(cmd.Name, await _houseQuery.GetAllHouseNames());
                if(!nameResult.IsSuccess)
                    return await response.ErrorResponse
                    (response, nameResult.DomainErrorMessage, _logger, "gfd");

            domainHouse.SetDescription(cmd.Description);
            
           
            var persistanceHouse = _mapping.MapToPersistence(domainHouse);

            if (!await _houseCommand.AddHouse(persistanceHouse))
            {
                return await response.ErrorResponse
                    (response, "Could not presist house to database", _logger);
            }

            var houseUser = new HouseUserEntity(persistanceHouse, user);
            if (!await _houseCommand.AddHouseUser(houseUser))
            {
                return await response.ErrorResponse
                   (response, "User attachment to house could not be persisted", _logger);
 
            }
            HouseToUserDTO data = new(
                Name: domainHouse.Name,
                HouseId: domainHouse.Id
                );
             return await response.SuccessResponse(response, data);
        }

        public async Task<ServiceResponse<MemberToHouseDTO>> AttachMemberToHouse
            (RegisterMemberToHouseCommand command)
        {
            ServiceResponse<MemberToHouseDTO> response = new();

            var user = await _userQueryRepository.GetUserByEmail(command.Email);
            if (user == null)
                 return await response.ErrorResponse
                   (response, "No user exist in database", _logger);


            var house = await _houseQuery.GetHouseByInvite(command.Invitation);
            if (house is null)
                return await response.ErrorResponse
                      (response, "Something went wrong.", _logger, "Could not persist house to database");
            

            var houseUser = new HouseUserEntity(house, user);
            if (!await _houseCommand.AddHouseUser(houseUser))
                return await response.ErrorResponse
                        (response, "Something went wrong.", _logger, "User attachment to house could not be persisted");


            MemberToHouseDTO data = new MemberToHouseDTO(
                  HouseName: house.Name,
                  Alias: user.Alias
                   );

            return await response.SuccessResponse(response, data);
        }
    }
}
