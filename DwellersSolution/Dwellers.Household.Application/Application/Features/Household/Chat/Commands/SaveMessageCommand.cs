using MediatR;

namespace Dwellers.Household.Application.Features.Household.Chat.Commands
{
    public record SaveMessageCommand(
        string Message,
        string UserId,
        Guid ConversationId
        ) : IRequest<SaveMessageResult>;

}