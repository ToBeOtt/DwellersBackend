using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Requests.DwellerEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("events")]
    public class DashboardController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;

        public DashboardController(
          ICommandHandlerFactory commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpGet("GetDashboardBulletins")]
        public async Task<IActionResult> GetDashboardBulletins()
        {
            var houseIdClaim = User.FindFirst("HouseId") ?? throw new InvalidCredentialException();

            return Ok();
            //var cmd = new GetDashboardBulletinsCommand(
            //    HouseId: new Guid(houseIdClaim.Value));

            //var getDashboardNotesResult = await _mediator.Send(cmd);
            //return Ok(getDashboardNotesResult);
        }

    }
}
