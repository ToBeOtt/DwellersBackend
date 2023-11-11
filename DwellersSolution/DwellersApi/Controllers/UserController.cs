using Dwellers.Household.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using System.Security.Authentication;

namespace DwellersApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly ICommandHandlerFactory _commandHandler;
        private readonly IQueryHandlerFactory _queryHandler;

        public UserController(
            ISender mediator,
            ICommandHandlerFactory commandHandler,
            IQueryHandlerFactory queryHandler
            )
        {
            
            _mediator = mediator;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
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