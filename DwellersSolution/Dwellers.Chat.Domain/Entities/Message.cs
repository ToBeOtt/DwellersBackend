
using SharedKernel.Domain;

namespace Dwellers.Chat.Domain.Entities
{
    public sealed class Message : BaseEntity
    {
        private Guid _messageId;
        private string _messageText;

        private string _dwellerId;
        private Guid _conversationId;

        private bool _isArchived;
        private DateTime _isCreated;
        private DateTime _isModified;

        private Message(
            string dwellerID,
            Guid conversationId,
            string messageText)
        {
            _messageId = Guid.NewGuid();

            _dwellerId = dwellerID;
            _conversationId = conversationId;
            _messageText = messageText;

            _isCreated = DateTime.UtcNow;
            _isArchived = false;
        }
        public static class MessageFactory
        {
            public static async Task<Message> Create
                (string dwellerId,
                 Guid conversationId,
                 string messageText)
            {
                var message = new Message(dwellerId, conversationId, messageText);
                return message;
            }
        }


    }
}

