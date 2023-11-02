using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;

namespace Dwellers.Chat.Application.Services
{
    public class ChatQueryServices
    {
        private readonly ILogger<ChatQueryServices> _logger;
        private readonly IChatQueryRepository _chatQueryRepository;

        public ChatQueryServices(
            ILogger<ChatQueryServices> logger,
            IChatQueryRepository chatQueryRepository
            )
        {
            _logger = logger;
            _chatQueryRepository = chatQueryRepository;
        }

        public async Task<ChatServiceResponse<ICollection<DwellerMessageEntity>>> GetConversations(Guid HouseID)
        {
            ChatServiceResponse<ICollection<DwellerMessageEntity>> response = 
                new ChatServiceResponse<ICollection<DwellerMessageEntity>>();

            var conversation = await _chatQueryRepository.GetHouseholdConversation(HouseID);
            if (conversation == null)
            {
                response.IsSuccess = false;
                response.ValidationMessage = "Trouble fetching conversations associated to house.";
                return response;
            }

            var messages = await _chatQueryRepository.GetConversationMessages(conversation.Id);
            if (messages == null)
            {
                response.IsSuccess = false;
                response.ValidationMessage = "No conversation tied to house.";
                return response;
            }

            response.IsSuccess = true;
            response.Data = messages;
            response.ConversationID = conversation.Id;
            return response;
        }

    }
}
