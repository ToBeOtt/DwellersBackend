using Dwellers.Household.Application.Features.User;
using Dwellers.Household.Infrastructure.Data;
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
        private readonly DwellerDbContext _context;

        public UserController(
            ISender mediator,
            DwellerDbContext context
            )
        {
            _mediator = mediator;
            _context = context;
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
