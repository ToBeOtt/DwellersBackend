using Dwellers.Household.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace DwellersApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;

        public UserController(
            ISender mediator
            )
        {
            _mediator = mediator;
        }


        [HttpPost("SetProfilePhoto")]
        public async Task<IActionResult> SetProfilePhoto(IFormFile profilePhoto)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new UpdateUserCommand(
                UserId: userIdClaim.Value,
                ProfilePhoto: profilePhoto);

            var UpdateUserResult = await _mediator.Send(cmd);
            return Ok(UpdateUserResult);
        }
    }
}
