using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
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

        public async Task<ServiceResponse<GetConversationsDTO>> GetConversations(Guid HouseID)
        {
            ServiceResponse<GetConversationsDTO> response = new();

            var conversation = await _chatQueryRepository.GetHouseholdConversation(HouseID);
            if (conversation == null)
                return await response.ErrorResponse
                        (response, "Conversation could not be found or contains no messages.", _logger);  

            var messages = await _chatQueryRepository.GetConversationMessages(conversation.Id);
            if (messages == null)
                return await response.ErrorResponse
                          (response, "Conversation could not be found or contains no messages.", _logger);


            GetConversationsDTO data = new(
                ConversationMessages: messages,
                ConversationId: conversation.Id);

            return await response.SuccessResponse(response, data);
        }

    }
}
