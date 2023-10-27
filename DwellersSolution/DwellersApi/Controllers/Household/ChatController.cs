using Dwellers.Household.Application.Features.Household.Chat.Commands;
using Dwellers.Household.Application.Features.Household.Chat.Queries;
using Dwellers.Household.Contracts.Requests.Household.Chat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("chat")]
    public class ChatController : ControllerBase
    {
        private readonly ISender _mediator;

        public ChatController(
            ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("message")]
        public async Task<IActionResult> PersistMessage(SaveMessageRequest request)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new SaveMessageCommand(
            Message: request.Message,
            UserId: userIdClaim.Value,
            ConversationId: request.ConversationId
            );

            var saveMessageResult = await _mediator.Send(cmd);
            return Ok(saveMessageResult);
        }

        [HttpGet("GetHouseholdConversation")]
        public async Task<IActionResult> GetHouseholdConversation()
        {
            var houseIdClaim = User.FindFirst("HouseId");
            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var query = new GetHouseholdConversationQuery(
                HouseId: new Guid(houseIdClaim.Value)
                );

            var getHouseholdConversationResult = await _mediator.Send(query);
            return Ok(getHouseholdConversationResult);
        }
    }
}
