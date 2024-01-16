using Dwellers.Chat.Contracts.Result;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

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

        public async Task<DwellerResponse<GetConversationResult>> GetConversation(Guid HouseID)
        {
            DwellerResponse<GetConversationResult> response = new();

            var conversation = await _chatQueryRepository.GetHouseholdConversation(HouseID);
            if (conversation == null)
                return await response.ErrorResponse
                        ("Conversation could not be found or contains no messages.");  

            var messages = await _chatQueryRepository.GetConversationMessages(conversation.Id);
            if (messages == null)
                return await response.ErrorResponse
                          ("Conversation could not be found or contains no messages.");


            GetConversationResult data = new(
                ConversationId: conversation.Id);

            return await response.SuccessResponse(data);
        }

    }
}
