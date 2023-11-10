using Azure;
using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Domain;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using static Dwellers.Authentication.Application.Services.DTO.AuthenticationDTO;

namespace Dwellers.Authentication.Application.Services
{
    public class RegistrationService
    {
        private readonly ILogger<RegistrationService> _logger;
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(
            ILogger<RegistrationService> logger,
            IRegistrationRepository registrationRepository)
        {
            _logger = logger;
            _registrationRepository = registrationRepository;
        }

        public async Task<ServiceResponse<RegistrationDTO>> Register(string email, string alias, string password)
        {
            ServiceResponse<RegistrationDTO> response = new();

            if (await _registrationRepository.CheckNoUserExist(email))
                return await response.ErrorResponse
                        (response, "Email taken or wrong format", _logger);

            var user = new DbUser();

            var userCreationResult = await user.CreateUser(email, alias);
            if (!userCreationResult.IsSuccess)
                return await response.ErrorResponse
                        (response, "Could not create user.", _logger, userCreationResult.DomainErrorMessage);

            var result = await _registrationRepository.AddUser(user, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                        (response, "Could not create user.", _logger, userCreationResult.DomainErrorMessage);

            RegistrationDTO data = new(
              DbUser: user);
            return await response.SuccessResponse(response, data);
        }

        public async Task<ServiceResponse<RegistrationDTO>> AttachHouseTo(string email, string alias, string password)
        {
            ServiceResponse<RegistrationDTO> response = new();

            if (await _registrationRepository.CheckNoUserExist(email))
                return await response.ErrorResponse
                        (response, "Duplicate email.", _logger);

            var user = new DbUser();
            var userCreationResult = await user.CreateUser(email, alias);
            if (!userCreationResult.IsSuccess)
                return await response.ErrorResponse
                        (response, "Could not create user.", _logger);

            var result = await _registrationRepository.AddUser(user, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                        (response, "Could not create user.", _logger);

            RegistrationDTO data = new(
              DbUser: user);
            return await response.SuccessResponse(response, data);
        }
    }
}
