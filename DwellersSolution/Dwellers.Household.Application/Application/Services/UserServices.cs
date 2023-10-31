using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Application.Services.Responses;
using Dwellers.Household.Domain.Entities;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Services
{
    public class UserServices
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly ILogger<UserServices> _logger;

        public UserServices(
            IUserCommandRepository userCommandRepository,
            ILogger<UserServices> logger)
        {
            _userCommandRepository = userCommandRepository;
            _logger = logger;
        }

        public async Task<HouseholdServiceResponse<bool>> CreateDwellerUser
            (string dbUserId, string dbUserEmail, string dbUserAlias)
        {
            HouseholdServiceResponse<bool> response = new();

            DwellerUserEntity dwellerUser = new();
            dwellerUser.Id = dbUserId;
            dwellerUser.Email = dbUserEmail;
            dwellerUser.Alias = dbUserAlias;

            if (! await _userCommandRepository.AddUser(dwellerUser))
            {
                response.IsSuccess = false;
                response.ErrorMessage = "User could not be persisted.";
                return response;
            }
            response.IsSuccess = true;
            return response;
        }
    }
}
