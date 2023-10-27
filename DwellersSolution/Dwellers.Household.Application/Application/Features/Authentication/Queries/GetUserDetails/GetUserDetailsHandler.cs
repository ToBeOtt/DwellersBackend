using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Features.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Authentication.Queries.GetUserDetails
{

    public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResult>
    {
        private readonly ILogger<GetUserDetailsHandler> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public GetUserDetailsHandler(
            ILogger<GetUserDetailsHandler> logger,
            IUserQueryRepository userQueryRepository,
            IHouseQueryRepository houseQueryRepository)
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseQueryRepository = houseQueryRepository;
        }

        public async Task<GetUserDetailsResult> Handle(GetUserDetailsQuery query, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(query.UserId);
            if (user is null)
            {
                _logger.LogInformation("User not found");
                throw new EntityNotFoundException("User not found");
            }
            var house = await _houseQueryRepository.GetHouseById(query.HouseId);
            if (house is null)
            {
                _logger.LogInformation("House not found");
                throw new EntityNotFoundException("House not found");
            }
            return new GetUserDetailsResult(
                 user,
                 house
                 );
        }
    }
}

