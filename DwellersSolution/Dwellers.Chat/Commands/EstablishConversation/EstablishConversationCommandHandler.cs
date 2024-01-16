using Dwellers.Chat.Contracts.Commands;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Graph.Models.Security;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Chat.Commands.EstablishConversation
{ 
     public class EstablishConversationCommandHandler : ICommandHandler<EstablishConversationCommand, DwellerUnit>
    {
        private readonly ILogger<EstablishConversationCommandHandler> _logger;
        private readonly IChatQueryRepository _chatQueryRepository;
        private readonly IChatCommandRepository _chatCommandRepository;

        public EstablishConversationCommandHandler(
            ILogger<EstablishConversationCommandHandler> logger,
            IChatQueryRepository chatQueryRepository,
            IChatCommandRepository chatCommandRepository)
        {
            _logger = logger;
            _chatQueryRepository = chatQueryRepository;
            _chatCommandRepository = chatCommandRepository;
        }

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (EstablishConversationCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<bool> response = new();

            // get conversation

            // make establish conversation member through method in conversation

            // persist conversation member

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
