using Dwellers.Household.Application.Interfaces.Household.Chat;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Chat.Queries
{
    public class GetHouseholdConversationQueryHandler : IRequestHandler<GetHouseholdConversationQuery, GetHouseholdConversationResult>
    {
        private readonly ILogger<GetHouseholdConversationQueryHandler> _logger;
        private readonly IChatQueryRepository _chatQueryRepository;

        public GetHouseholdConversationQueryHandler(
            ILogger<GetHouseholdConversationQueryHandler> logger,
            IChatQueryRepository chatQueryRepository
            )
        {
            _logger = logger;
            _chatQueryRepository = chatQueryRepository;
        }

        public async Task<GetHouseholdConversationResult> Handle(GetHouseholdConversationQuery query, CancellationToken cancellationToken)
        {
            var conversation = await _chatQueryRepository.GetHouseholdConversation(query.HouseId);
            if (conversation == null)
            {
                // felhantering
            }

            var messages = await _chatQueryRepository.GetConversationMessages(conversation.Id);
            if (messages == null)
            {
                // felhantering
            }

            return new GetHouseholdConversationResult(
               AllMessages: messages,
               ConversationId: conversation.Id
               );

        }
    }
}
