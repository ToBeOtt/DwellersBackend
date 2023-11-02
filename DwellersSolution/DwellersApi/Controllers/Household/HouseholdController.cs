using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Household.Contracts.Queries;
using Dwellers.Household.Contracts.Requests;
using Dwellers.Household.Services;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Security.Authentication;
using Tavis.UriTemplates;

namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("household")]
    public class HouseholdController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly UserServices _userServices;

        public HouseholdController(
            ISender mediator,
            UserServices userServices)
        {
            _mediator = mediator;
            _userServices = userServices;
        }


        [HttpGet("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails(FetchUserDetailsRequest request)
        {
            {
                var userIdClaim = User.FindFirst("UserId");
                var houseIdClaim = User.FindFirst("HouseId");

                if (userIdClaim is null || houseIdClaim is null)
                {
                    return BadRequest();
                }

                var query = new FetchUserDataQuery(
                    UserId : userIdClaim.Value,
                    HouseId: new Guid(houseIdClaim.Value));

                var result = await _userServices.FetchUserDetails(query);
                if(!result.IsSuccess)
                {
                    return BadRequest(result.ErrorResponse);
                }
                return Ok(result);
            }
        }
    }
}

