namespace Dwellers.Chat.Domain.Entities
{
    public class DwellerMessage
    {
        public Guid ID { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string UserID { get; set; }

        public HouseConversation Conversation { get; set; }

        public DwellerMessage()
        {
        }

        public DwellerMessage(
            string userID,
            string messageText,
            HouseConversation conversation)
        {
            ID = Guid.NewGuid();
            UserID = userID;
            MessageText = messageText;
            Timestamp = DateTime.Now;
            IsRead = false;
            Conversation = conversation;
        }
    }
}
