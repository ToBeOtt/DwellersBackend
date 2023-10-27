using MediatR;

namespace Dwellers.Household.Application.Features.Household.Chat.Queries
{
    public record GetHouseholdConversationQuery(
        Guid HouseId) : IRequest<GetHouseholdConversationResult>;
}
