namespace Dwellers.Chat.Domain.Entities
{
    public class DwellerMessage
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string UserId { get; set; }

        public Guid DwellerConversationId { get; set; }
        public DwellerConversation Conversation { get; set; }

        public DwellerMessage()
        {
        }

        public DwellerMessage(
            string userID,
            string messageText,
            DwellerConversation conversation)
        {
            Id = Guid.NewGuid();
            UserId = userID;
            MessageText = messageText;
            Timestamp = DateTime.Now;
            IsRead = false;
            Conversation = conversation;
        }
    }
}
