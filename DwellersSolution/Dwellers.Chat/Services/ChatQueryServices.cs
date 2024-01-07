using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;
using static Dwellers.Chat.Services.DTO.ChatServiceDTO;

namespace Dwellers.Chat.Services
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

        public async Task<DwellerResponse<GetConversationsDTO>> GetConversations(Guid HouseID)
        {
            DwellerResponse<GetConversationsDTO> response = new();

            var conversation = await _chatQueryRepository.GetHouseholdConversation(HouseID);
            if (conversation == null)
                return await response.ErrorResponse
                        ("Conversation could not be found or contains no messages.");  

            var messages = await _chatQueryRepository.GetConversationMessages(conversation.Id);
            if (messages == null)
                return await response.ErrorResponse
                          ("Conversation could not be found or contains no messages.");


            GetConversationsDTO data = new(
                ConversationMessages: messages,
                ConversationId: conversation.Id);

            return await response.SuccessResponse(data);
        }

    }
}
