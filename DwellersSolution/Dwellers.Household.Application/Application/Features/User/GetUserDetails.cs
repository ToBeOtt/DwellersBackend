using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.User
{
    public record GetUserDetailsQuery(
    string UserId,
    Guid HouseId) : IRequest<GetUserDetailsResult>;

    public record GetUserDetailsResult(
      DwellerUserEntity User,
      HouseEntity House);


    public class GetUserDetails : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResult>
    {
        private readonly ILogger<GetUserDetails> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public GetUserDetails(
            ILogger<GetUserDetails> logger,
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

