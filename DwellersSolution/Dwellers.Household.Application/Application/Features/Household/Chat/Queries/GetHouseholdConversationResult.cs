using Dwellers.Household.Domain.Entities.Chat;

namespace Dwellers.Household.Application.Features.Household.Chat.Queries
{
    public record GetHouseholdConversationResult(
        ICollection<DwellerMessage> AllMessages,
        Guid ConversationId);
}
