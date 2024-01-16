using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dwellers.Chat.Domain.Entities.Conversation;

namespace Dwellers.Chat.Domain.Entities
{
    public sealed class MemberInConversation : ValueObject
    {
        private Guid _id;
        private ConversationId _conversationId;
        private Guid _dwellingId;
        private DateTime _addedToConversation;

        internal MemberInConversation(ConversationId conversationId, Guid dwellingId)
        {
            _id = Guid.NewGuid();
            _conversationId = conversationId;
            _dwellingId = dwellingId;
            _addedToConversation = DateTime.UtcNow;
        }
    }
}
