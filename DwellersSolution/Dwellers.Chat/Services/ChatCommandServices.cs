using Azure;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Chat.Services
{
    public class ChatCommandServices
    {

        private readonly ILogger<ChatCommandServices> _logger;
        private readonly IChatCommandRepository _chatCommandRepository;
        private readonly IChatQueryRepository _chatQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public ChatCommandServices(
            ILogger<ChatCommandServices> logger,
            IChatCommandRepository chatCommandRepository,
            IChatQueryRepository chatQueryRepository,
            IHouseQueryRepository houseQueryRepository,
            IUserQueryRepository userQueryRepository
            )
        {
            _logger = logger;
            _chatCommandRepository = chatCommandRepository;
            _chatQueryRepository = chatQueryRepository;
            _houseQueryRepository = houseQueryRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<ServiceResponse<bool>> SaveMessage
            (string messageText, string userId, Guid conversationId)
        {
            ServiceResponse<bool> response = new();

            var conversation = await _chatQueryRepository.GetConversation(conversationId);
            if (conversation is null)
                return await response.ErrorResponse
                       (response, "Chat not found or empty.", _logger);

            var user = await _userQueryRepository.GetUserById(userId);
            if (user is null)
                return await response.ErrorResponse
                        (response, "Message could not be sent.", _logger, "Unable to persist message");
       

            DwellerMessageEntity message = new DwellerMessageEntity(messageText, user, conversation);

            if (!await _chatCommandRepository.PersistMessage(message))
                return await response.ErrorResponse
                        (response, "Message could not be sent.", _logger, "Unable to persist message");
            
            return await response.SuccessResponse(response);
        }

        public async Task<ServiceResponse<bool>> EstablishConversation
            (Guid houseId, string houseName)
        {
            ServiceResponse<bool> response = new();

            DwellerConversationEntity conversation = new DwellerConversationEntity(houseName);
            if (!await _chatCommandRepository.PersistConversation(conversation))
                return await response.ErrorResponse
                        (response, "Conversation could not be created.", _logger);

            var house = await _houseQueryRepository.GetHouseById(houseId);
            if (house == null)
                return await response.ErrorResponse
                        (response, "Conversation could not be created.", _logger, "Unable to persist conversation");

            HouseConversationEntity houseConversation = new HouseConversationEntity(house, conversation);
            if (!await _chatCommandRepository.PersistHouseConversation(houseConversation))
                return await response.ErrorResponse
                        (response, "Conversation could not be created.", _logger, "Conversation could not be linked to household");

            return await response.SuccessResponse(response);
        }
    }
}

