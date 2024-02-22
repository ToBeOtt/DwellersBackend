using Dwellers.Common.Application.Contracts.Commands.Bulletins;
using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Contracts.Queries.DwellerEvents;
using Dwellers.Common.Application.Contracts.Requests.DwellerEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using System.Security.Authentication;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("events")]
    public class DwellerEventsController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;

        public DwellerEventsController(
          ICommandHandlerFactory commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(AddEventRequest request)
        {

            var userIdClaim = User.FindFirst("UserId");
            var houseIdClaim = User.FindFirst("HouseId");
            
            if (userIdClaim is null || houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new AddEventCommand(
                Title: request.Title,
                Desc: request.Desc,
                EventDate: request.EventDate,
                EventScope: request.EventScope,
            DwellerId: userIdClaim.Value,
                DwellingId: new Guid(houseIdClaim.Value));

            var handler = _commandHandler.GetHandler<AddEventCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);

        }

        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEvent(Guid eventId)
        {

            var query = new GetEventQuery(
                EventId: eventId);

            var handler = _commandHandler.GetHandler<GetEventQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var query = new GetAllEventsQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var handler = _commandHandler.GetHandler<GetAllEventsQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetUpcomingEvents")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var query = new GetUpcomingEventsQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var handler = _commandHandler.GetHandler<GetUpcomingEventsQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
