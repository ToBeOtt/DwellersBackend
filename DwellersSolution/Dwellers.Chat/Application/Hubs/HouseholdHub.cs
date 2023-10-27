using Microsoft.AspNetCore.SignalR;

namespace Dwellers.Chat.Application.Hubs
{
    public class HouseholdHub : Hub
    {
        public async Task JoinConversationGroup(string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
        }

        public async Task LeaveConversationGroup(string conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId);
        }

        public async Task NewMessage(string message, string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);

            await Clients.Group(conversationId).SendAsync("ReceiveMessage", message);
        }
    }
}
