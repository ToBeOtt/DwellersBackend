using Dwellers.Chat.Services;
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
        private readonly ChatCommandServices _messageCommandService;
        private readonly ChatQueryServices _chatQueryServices;

        public ChatController(
            ChatCommandServices messageCommandService,
            ChatQueryServices chatQueryServices)
        {
           _messageCommandService = messageCommandService;
           _chatQueryServices = chatQueryServices;
        }

        public class MessageDto
        {
            public Guid ConversationId { get; set; }
            public string Message { get; set; }
        }

        [HttpPost("message")]
        public async Task<IActionResult> PersistMessage([FromBody] MessageDto messageDto)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
            {
                throw new InvalidCredentialException();
            }
            var result = await _messageCommandService.SaveMessage(messageDto.Message, userIdClaim.Value, messageDto.ConversationId);

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpGet("GetHouseholdConversation")]
        public async Task<IActionResult> GetHouseholdConversation()
        {
            var houseIdClaim = User.FindFirst("HouseId");
            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var result = await _chatQueryServices.GetConversations(new Guid(houseIdClaim.Value));

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
    }
}
