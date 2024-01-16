
using SharedKernel.Domain;

namespace Dwellers.Chat.Domain.Entities
{
    public class Conversation : BaseEntity, IAggregateRoot
    {
        public readonly record struct ConversationId(Guid Value);
        public ConversationId Id { get; set; }
        private string _nameOfConversation;

        private List<Message> _messages;
        private List<MemberInConversation> _members; // <- dwellings

        private bool _isArchived;
        private DateTime _isCreated;
        private DateTime _isModified;

        private Conversation(string nameOfConversation)
        {
            Id = new ConversationId(Guid.NewGuid());
            _nameOfConversation = nameOfConversation;

            _messages = new List<Message>(); 

            _isCreated = DateTime.UtcNow;
            _isArchived = false;
        }
        public static class ConversationFactory
        {
            public static async Task<Conversation> Create(string nameOfConversation)
            {
                var message = new Conversation(nameOfConversation);
                return message;
            }
        }

        // Make sure a conversation cannot be archived if there is messages not archived.

        

    }
}

