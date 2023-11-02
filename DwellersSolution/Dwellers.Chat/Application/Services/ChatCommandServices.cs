using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Microsoft.Extensions.Logging;

namespace Dwellers.Chat.Application.Services
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

        public async Task<ChatServiceResponse<bool>> SaveMessage(string messageText, string userId, Guid conversationId)
            {
            ChatServiceResponse<bool> response =
               new ChatServiceResponse<bool>();
                        
            var conversation = await _chatQueryRepository.GetConversation(conversationId);
            if (conversation is null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "There was no chat-history.";
                _logger.LogInformation("Unable to create conversation");
                return response;
            }


            var user = await _userQueryRepository.GetUserById(userId);
            if (user is null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "No user tied to message";
                _logger.LogInformation("Unable to persist message");
                return response;
            }

            DwellerMessageEntity message = new DwellerMessageEntity(messageText, user, conversation);

            if (!await _chatCommandRepository.PersistMessage(message))
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Unable to persist message in database.";
                _logger.LogInformation("Unable to persist message in database");
                return response;
            }

            response.IsSuccess = true;
            return response; 
        }

        public async Task<ChatServiceResponse<bool>> EstablishConversation
            (Guid houseId, string houseName)
        {
            ChatServiceResponse<bool> response =
               new ChatServiceResponse<bool>();

            DwellerConversationEntity conversation = new DwellerConversationEntity(houseName);
            if (!await _chatCommandRepository.PersistConversation(conversation))
            {
                _logger.LogInformation("Conversation could not be implemented");
                response.IsSuccess = false;
                response.ErrorMessage = "Conversation could not be created";
                return response;
            }

            var house = await _houseQueryRepository.GetHouseById(houseId);
            if (house == null)
            {
                _logger.LogInformation("Related household could not be found");
                response.IsSuccess = false;
                response.ErrorMessage = "Related household could not be found";
                return response;
            }


            HouseConversationEntity houseConversation = new HouseConversationEntity(house, conversation);
            if (!await _chatCommandRepository.PersistHouseConversation(houseConversation))
            {
                _logger.LogInformation("Conversation could not be linked to household");
                response.IsSuccess = false;
                response.ErrorMessage = "Could not establish a conversation";
                return response;
            }

            response.IsSuccess = true;
            return response;
        }
    }
}

