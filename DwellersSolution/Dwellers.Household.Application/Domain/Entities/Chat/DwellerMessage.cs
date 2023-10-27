using Dwellers.Household.Domain.ValueObjects;
using Microsoft.Graph.Models;

namespace Dwellers.Household.Domain.Entities.Chat
{
    public class DwellerMessage
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public DwellerUser User { get; set; }

        public DwellerConversation Conversation { get; set; }

        public DwellerMessage()
        {
        }

        public DwellerMessage(
            DwellerUser user,
            string messageText,
            DwellerConversation conversation)
        {
            Id = Guid.NewGuid();
            User = user;
            MessageText = messageText;
            Timestamp = DateTime.Now;
            IsRead = false;
            Conversation = conversation;
        }
    }
}
