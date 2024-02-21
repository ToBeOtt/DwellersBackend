using Dwellers.Common.Application.Contracts.Queries.Dwellers;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;

namespace DwellersApi.Controllers.Common.ApplicationModule
{
    [ApiController]
    [Authorize]
    [Route("Dwellers")]
    public class DwellerController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;

        public DwellerController(
            ICommandHandlerFactory commandHandler)
        {
            _commandHandler = commandHandler;
        }


        [HttpGet("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            {
                var userIdClaim = User.FindFirst("UserId");
                var houseIdClaim = User.FindFirst("HouseId");

                if (userIdClaim is null || houseIdClaim is null)
                {
                    return BadRequest();
                }

                var query = new GetDwellerDetailsQuery(
                    DwellerId: userIdClaim.Value,
                DwellingId: new Guid(houseIdClaim.Value));

                var handler = _commandHandler.GetHandler<GetDwellerDetailsQuery, GetDwellerDetailsResult>();
                var result = await handler.Handle(query, new CancellationToken());

                if (!result.IsSuccess)
                {
                    return BadRequest(result.ErrorResponse);
                }
                return Ok(result);
            }
        }
    }
}

