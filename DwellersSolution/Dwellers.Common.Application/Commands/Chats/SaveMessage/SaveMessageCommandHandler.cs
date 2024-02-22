using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Interfaces.Chats;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Common.Application.Commands.Chats.SaveMessage
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
            DwellerMessage message = new(cmd.MessageText, cmd.DwellerId, cmd.ConversationId);

            if (!await _chatCommandRepository.AddMessageAsync(message))
                return await response.ErrorResponse("Message could not be sent.");

            return await response.SuccessResponse();
        }
    }
}
