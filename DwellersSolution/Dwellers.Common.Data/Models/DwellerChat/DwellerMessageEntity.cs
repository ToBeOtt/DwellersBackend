using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Data.Models.DwellerChat
{
    public class DwellerMessageEntity
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        public DwellerUserEntity User { get; set; }
        public string UserId { get; set; }

        public Guid ConversationId { get; set; }
        public DwellerConversationEntity Conversation { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellerMessageEntity() { }
        public DwellerMessageEntity(string message, DwellerUserEntity user, DwellerConversationEntity conversation)
        {
            Id = Guid.NewGuid();
            MessageText = message;
            User = user;
            Conversation = conversation;
        }
    }
}
