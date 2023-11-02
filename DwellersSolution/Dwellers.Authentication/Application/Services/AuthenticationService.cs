using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Application.Services.Responses;
using Dwellers.Authentication.Domain;
using Microsoft.Extensions.Logging;

namespace Dwellers.Authentication.Application.Services
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(
            IAuthenticationRepository authenticationRepository,
            IJwtTokenRepository jwtTokenRepository,
            ILogger<AuthenticationService> logger)
        {
            _authenticationRepository = authenticationRepository;
            _jwtTokenRepository = jwtTokenRepository;
            _logger = logger;
        }


        public async Task<AuthenticationServiceResponse<DbUser>> Login
            (string email, string password, Guid houseId)
        {
            AuthenticationServiceResponse<DbUser> authResponse = new AuthenticationServiceResponse<DbUser>();

            var user = await _authenticationRepository.GetUserByEmail(email);
            if (user == null)
            {
                _logger.LogInformation("User could not be found");
                authResponse.IsSuccess = false;
                authResponse.ErrorMessage = "Could not login.";
                return authResponse;
            }

            var result = await _authenticationRepository.CheckLoginCredentials(user.UserName, password);
            if (!result.Succeeded)
            {
                _logger.LogInformation("Invalid credentials");
                authResponse.IsSuccess = false;
                authResponse.ErrorMessage = "Could not login.";
                return authResponse;
            }

            var token = await _jwtTokenRepository.GenerateToken(user, houseId);

            authResponse.IsSuccess = true;
            authResponse.Token = token;
            authResponse.Data = user;
            return authResponse;
        }
    }
}
