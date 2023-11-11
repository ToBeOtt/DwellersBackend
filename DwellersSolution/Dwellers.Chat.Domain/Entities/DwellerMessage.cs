using SharedKernel.Domain.DomainModels;

namespace Dwellers.Chat.Domain.Entities
{
    public class DwellerMessage : BaseEntity
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string UserId { get; set; }

        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public DwellerMessage()
        {
        }

        public DwellerMessage(
            string userID,
            string messageText)
        {
            Id = Guid.NewGuid();
            UserId = userID;
            MessageText = messageText;
            Timestamp = DateTime.Now;
            IsRead = false;
            IsCreated = DateTime.Now;
            IsArchived = false;
        }
    }
}
