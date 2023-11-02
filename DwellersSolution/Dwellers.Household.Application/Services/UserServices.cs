using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Dwellers.Household.Contracts.Commands;
using Dwellers.Household.Contracts.Queries;
using Dwellers.Household.Services.DTO;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Household.Services
{
    public class UserServices
    {
        private readonly IUserCommandRepository _userCommand;
        private readonly IUserQueryRepository _userQuery;
        private readonly IHouseQueryRepository _houseQuery;
        private readonly ILogger<UserServices> _logger;

        public UserServices(
            IUserCommandRepository userCommandRepository,
            IUserQueryRepository userQuery,
            IHouseQueryRepository houseQuery,
            ILogger<UserServices> logger)
        {
            _userCommand = userCommandRepository;
            _userQuery = userQuery;
            _houseQuery = houseQuery;
            _logger = logger;
        }

        public async Task<ServiceResponse<bool>> CreateDwellerUser
            (string dbUserId, string dbUserEmail, string dbUserAlias)
        {
            ServiceResponse<bool> response = new();

            DwellerUserEntity dwellerUser = new();
            dwellerUser.Id = dbUserId;
            dwellerUser.Email = dbUserEmail;
            dwellerUser.Alias = dbUserAlias;

            if (!await _userCommand.AddUser(dwellerUser))
                return await response.ReturnError(response, "User could not be persisted.", _logger);
       
            response.IsSuccess = true;
            return response;
        }

        public async Task<ServiceResponse<DwellerUserEntity>> UpdateUserInformation
            (UpdateUserCommand cmd)
        {
            ServiceResponse<DwellerUserEntity> response = new();

            var user = await _userQuery.GetUserById(cmd.UserId);
            if (user is null)
                return await response.ReturnError
                    (response, "User could not be found.", _logger, 
                    "An error occurred while updating the user profile photo.");
           

            response.IsSuccess = true;
            response.Data = user;
            return response;
        }

        public async Task<ServiceResponse<UserDetailsDTO>> FetchUserDetails
            (FetchUserDataQuery query)
        {
            ServiceResponse<UserDetailsDTO> response = new();
            var user = await _userQuery.GetUserById(query.UserId);
            if (user is null)
                return await response.ReturnError(response, "User details could not be fetched.", _logger);

            
            var house = await _houseQuery.GetHouseById(query.HouseId);
            if (house is null)
                return await response.ReturnError
                    (response, "User details could not be fetched.", _logger, "House not found in database.");


            UserDetailsDTO data = new(
                User: user,
                House: house
                );
            return await response.ReturnSuccess(response, data);
        }
    }
}
