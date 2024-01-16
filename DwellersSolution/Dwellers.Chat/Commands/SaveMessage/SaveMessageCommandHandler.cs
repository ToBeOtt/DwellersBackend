using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Chat.Contracts.Commands;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Chat.Commands.SaveMessage
{
    public class SaveMessageCommandHandler : ICommandHandler<SaveMessageCommand, DwellerUnit>
    {
        private readonly ILogger<SaveMessageCommandHandler> _logger;
        private readonly IChatQueryRepository _chatQueryRepository;
        private readonly IChatCommandRepository _chatCommandRepository;

        public SaveMessageCommandHandler(
            ILogger<SaveMessageCommandHandler> logger,
            IChatQueryRepository chatQueryRepository,
            IChatCommandRepository chatCommandRepository)
        {
            _logger = logger;
            _chatQueryRepository = chatQueryRepository;
            _chatCommandRepository = chatCommandRepository;
        }

        public async Task<DwellerResponse<DwellerUnit>> Handle
            (SaveMessageCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var conversation = await _chatQueryRepository.GetConversation(cmd.ConversationId);
            if (conversation is null)
                return await response.ErrorResponse("Chat not found or empty.");

            // Create new message
            var message = await Message.MessageFactory.Create
                    (cmd.DwellerId, cmd.ConversationId, cmd.MessageText);

            if (!await _chatCommandRepository.PersistMessage(message))
                return await response.ErrorResponse("Message could not be sent.");

            return await response.SuccessResponse();
        }
    }
}
