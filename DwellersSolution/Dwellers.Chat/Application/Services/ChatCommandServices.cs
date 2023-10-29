using Dwellers.Chat.Application.Interfaces;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Chat.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace Dwellers.Chat.Application.Services
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

        public async Task<ChatServiceResponse<bool>> SaveMessage(string message, string userId, Guid conversationId)
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

            DwellerMessage dm = new DwellerMessage(userId, message, conversation);

            if (!await _chatCommandRepository.PersistMessage(dm))
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

            DwellerConversation dwellerConversation = new DwellerConversation(houseName);
            if (!await _chatCommandRepository.PersistConversation(dwellerConversation))
            {
                _logger.LogInformation("Conversation could not be implemented");
                throw new Exception("Persistance failed");
            }

            HouseConversation houseConversation = new HouseConversation(houseId, dwellerConversation.Id);
            if (!await _chatCommandRepository.PersistHouseConversation(houseConversation))
            {
                _logger.LogInformation("Conversation could not be linked to household");
                throw new Exception("Persistance failed");
            }

            response.IsSuccess = true;
            return response;
        }
    }
}

