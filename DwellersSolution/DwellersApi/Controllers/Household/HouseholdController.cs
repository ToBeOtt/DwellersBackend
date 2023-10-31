using Dwellers.Household.Application.Features.User;
using Dwellers.Household.Contracts.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("household")]
    public class HouseholdController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public HouseholdController(
            ISender mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            {
                var userIdClaim = User.FindFirst("UserId");
                var houseIdClaim = User.FindFirst("HouseId");

                if (userIdClaim is null || houseIdClaim is null)
                {
                    throw new InvalidCredentialException();
                }

                var request = new GetUserDetailsRequest(userIdClaim.Value, Guid.Parse(houseIdClaim.Value));

                var query = _mapper.Map<GetUserDetailsQuery>(request);

                var GetUserDetailsResult = await _mediator.Send(query);

                return Ok(GetUserDetailsResult);
            }
        }
    }
}

