using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Chat;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities.Chat;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Chat.Commands
{
    public class SaveMessageCommandHandler : IRequestHandler<SaveMessageCommand, SaveMessageResult>
    {
        private readonly ILogger<SaveMessageCommandHandler> _logger;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly IChatCommandRepository _chatCommandRepository;
        private readonly IChatQueryRepository _chatQueryRepository;

        public SaveMessageCommandHandler(
            ILogger<SaveMessageCommandHandler> logger,
            IUserQueryRepository userQueryRepository,
            IHouseQueryRepository houseQueryRepository,
            IChatCommandRepository chatCommandRepository,
            IChatQueryRepository chatQueryRepository
            )
        {
            _logger = logger;
            _userQueryRepository = userQueryRepository;
            _houseQueryRepository = houseQueryRepository;
            _chatCommandRepository = chatCommandRepository;
            _chatQueryRepository = chatQueryRepository;
        }
        public async Task<SaveMessageResult> Handle(SaveMessageCommand cmd, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(cmd.UserId);
            if (user is null)
            {
                _logger.LogInformation("Could not find entity in database");
                throw new EntityNotFoundException("No user found");
            }

            var conversation = await _chatQueryRepository.GetConversation(cmd.ConversationId);
            if (conversation is null)
            {
                _logger.LogInformation("Unable to create conversation");
                throw new NullReferenceException();
            }

            DwellerMessage dm = new DwellerMessage(user, cmd.Message, conversation);

            if (!await _chatCommandRepository.PersistMessage(dm))
            {
                _logger.LogInformation("Unable to persist message in database");
                throw new PersistanceFailedException("Unable to persist message in database");
            }

            return new SaveMessageResult(
            true);
        }
    }
}
