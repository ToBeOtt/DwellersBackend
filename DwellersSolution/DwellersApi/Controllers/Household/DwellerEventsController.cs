using Dwellers.Calendar.Contracts.Commands;
using Dwellers.Calendar.Contracts.Queries;
using Dwellers.Calendar.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("events")]
    public class DwellerEventsController : ControllerBase
    {
        private readonly ISender _mediator;

        public DwellerEventsController(
            ISender mediator)
        {
            _mediator = mediator;
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
                UserId: userIdClaim.Value,
                HouseId: new Guid(houseIdClaim.Value));

            var addEventResult = await _mediator.Send(cmd);
            return Ok(addEventResult);
        }

        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEvent(Guid eventId)
        {

            var cmd = new GetEventQuery(
                EventId: eventId);

            var getEventResult = await _mediator.Send(cmd);
            return Ok(getEventResult);
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new GetAllEventsQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var getAllEventsResult = await _mediator.Send(cmd);
            return Ok(getAllEventsResult);
        }

        [HttpGet("GetUpcomingEvents")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new GetUpcomingEventsQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var getUpcomingEventsResult = await _mediator.Send(cmd);
            return Ok(getUpcomingEventsResult);
        }
    }
}
