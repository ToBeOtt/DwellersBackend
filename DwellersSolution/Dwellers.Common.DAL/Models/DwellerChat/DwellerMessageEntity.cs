using Dwellers.Common.DAL.Models.Household;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.DAL.Models.DwellerChat
{
    public class DwellerMessageEntity
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        DwellerUserEntity User { get; set; }
        public string UserId { get; set; }

        public Guid ConversationId { get; set; }
        public DwellerConversationEntity Conversation { get; set; }

        public DwellerMessageEntity(string message, DwellerUserEntity user, DwellerConversationEntity conversation)
        {
            Id = Guid.NewGuid();
            MessageText = message;
            User = user;
            Conversation = conversation;
        }
    }
}
