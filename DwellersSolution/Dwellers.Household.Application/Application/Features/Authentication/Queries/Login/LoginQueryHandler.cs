using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Authentication;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResult>
    {
        private readonly ILogger<LoginQueryHandler> _logger;
        private readonly IJwtTokenRepository _jwtTokenGenerator;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public LoginQueryHandler(
            ILogger<LoginQueryHandler> logger,
            IJwtTokenRepository jwtTokenGenerator,
            IUserQueryRepository userQueryRepository,
            IHouseQueryRepository houseQueryRepository)
        {
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userQueryRepository = userQueryRepository;
            _houseQueryRepository = houseQueryRepository;
        }
        public async Task<LoginResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserByEmail(query.Email);
            if (user == null)
            {
                _logger.LogInformation("User could not be found");
                throw new LoginFailedException("Felaktig inloggning");
            }

            var houseUser = await _houseQueryRepository.GetHouseUserByUserID(user.Id);
            if(houseUser is null)
            {
                _logger.LogInformation("No house connected to user");
                throw new LoginFailedException("Du behöver ansluta dig till ett hus");
            }

            var result = await _userQueryRepository.CheckLoginCredentials(user.UserName, query.Password);
            if (!result.Succeeded)
            {
                _logger.LogInformation("Invalid credentials");
                throw new LoginFailedException("Felaktig inloggning");
            }

            var token = await _jwtTokenGenerator.GenerateToken(user, houseUser.HouseId);

            return new LoginResult(
                 user,
                 token
                 );
        }
    }
}
