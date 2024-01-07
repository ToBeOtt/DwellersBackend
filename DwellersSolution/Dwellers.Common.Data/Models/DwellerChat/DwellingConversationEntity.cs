namespace Dwellers.Common.Data.Models.DwellerChat
{
    public class DwellingConversationEntity
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }
        public Guid ConversationId { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellingConversationEntity()
        {
            
        }
        public DwellingConversationEntity(Guid dwellingId, Guid conversationId)
        {
            Id = Guid.NewGuid();
            DwellingId = dwellingId;
            ConversationId = conversationId;
        }

    }
}
