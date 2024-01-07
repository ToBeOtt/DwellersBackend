namespace Dwellers.Common.Data.Models.DwellerChat
{
    public class DwellerMessageEntity
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        public string DwellerId { get; set; }
        public Guid ConversationId { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellerMessageEntity() { }
        public DwellerMessageEntity(string message, string dwellerId, Guid conversationId)
        {
            Id = Guid.NewGuid();
            MessageText = message;
            DwellerId = dwellerId;
            ConversationId = conversationId;
        }
    }
}
