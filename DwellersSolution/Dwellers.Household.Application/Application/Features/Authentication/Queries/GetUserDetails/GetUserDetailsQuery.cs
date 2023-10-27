using Dwellers.Household.Application.Features.Authentication.Queries.GetUserDetails;
using MediatR;

namespace Dwellers.Household.Application.Authentication.Queries.GetUserDetails
{
    public record GetUserDetailsQuery(
       string UserId,
       Guid HouseId) : IRequest<GetUserDetailsResult>;
}
