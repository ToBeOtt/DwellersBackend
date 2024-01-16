using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Chat.Services
{
    public class ChatCommandServices
    {

        private readonly ILogger<ChatCommandServices> _logger;
        private readonly IChatCommandRepository _chatCommandRepository;
        private readonly IChatQueryRepository _chatQueryRepository;

        public ChatCommandServices(
            ILogger<ChatCommandServices> logger,
            IChatCommandRepository chatCommandRepository,
            IChatQueryRepository chatQueryRepository
            )
        {
            _logger = logger;
            _chatCommandRepository = chatCommandRepository;
            _chatQueryRepository = chatQueryRepository;
        }

        //public async Task<DwellerResponse<bool>> SaveMessage
        //    (string messageText, string userId, Guid conversationId)
        //{
        //    DwellerResponse<bool> response = new();

        //    var conversation = await _chatQueryRepository.GetConversation(conversationId);
        //    if (conversation is null)
        //        return await response.ErrorResponse
        //               ("Chat not found or empty.");

        //    DwellerMessageEntity message = new DwellerMessageEntity(messageText, userId, conversation.Id);

        //    if (!await _chatCommandRepository.PersistMessage(message))
        //        return await response.ErrorResponse
        //                ("Message could not be sent.");
            
        //    return await response.SuccessResponse();
        //}

        public async Task<DwellerResponse<bool>> EstablishConversation
            (Guid dwellingId, string houseName)
        {
            DwellerResponse<bool> response = new();

            DwellerConversationEntity conversation = new DwellerConversationEntity(houseName);
            if (!await _chatCommandRepository.PersistConversation(conversation))
                return await response.ErrorResponse
                        ("Conversation could not be created.");

            DwellingConversationEntity dwellingConversation = new DwellingConversationEntity(dwellingId, conversation.Id);
            if (!await _chatCommandRepository.PersistHouseConversation(dwellingConversation))
                return await response.ErrorResponse
                        ("Conversation could not be created.");

            return await response.SuccessResponse();
        }
    }
}

