using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Contracts.Queries.Chats;
using Dwellers.Common.Application.Contracts.Requests.Chats;
using Dwellers.Common.Application.Contracts.Results.Chats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers.ChatModule
{
    [ApiController]
    [Authorize]
    [Route("chat")]
    public class ChatController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;

        public ChatController(
          ICommandHandlerFactory commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public class MessageDto
        {
            public Guid ConversationId { get; set; }
            public string Message { get; set; }
        }

        [HttpPost("message")]
        public async Task<IActionResult> PersistMessage(SaveMessageRequest request)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
                throw new InvalidCredentialException();

            var cmd = new SaveMessageCommand(
                MessageText: request.Message,
                DwellerId: userIdClaim.Value,
                ConversationId: request.ConversationId);

            var handler = _commandHandler.GetHandler<SaveMessageCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

        [HttpGet("GetConversation")]
        public async Task<IActionResult> GetHouseholdConversation()
        {
            var dwellingIdClaim = User.FindFirst("HouseId");
            if (dwellingIdClaim is null)
                throw new InvalidCredentialException();

            var query = new GetConversationQuery(
               DwellingId: new Guid(dwellingIdClaim.Value)); 

            var handler = _commandHandler.GetHandler<GetConversationQuery, GetConversationResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
    }
}
