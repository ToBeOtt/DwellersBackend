using Dwellers.Common.Application.Contracts.Commands.Dwellers;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;
        private readonly IQueryHandlerFactory _queryHandler;

        public UserController(
            ICommandHandlerFactory commandHandler,
            IQueryHandlerFactory queryHandler
            )
        { 
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

            var cmd = new SetDwellerProfilePhotoCommand(
                DwellerId: userIdClaim.Value,
            DwellerPhoto: profilePhoto);

            var handler = _commandHandler.GetHandler<SetDwellerProfilePhotoCommand, DwellerResponse<DwellerUnit>>();
            var result = await handler.Handle(cmd, new CancellationToken());

            return Ok(result);
        }
    }
}