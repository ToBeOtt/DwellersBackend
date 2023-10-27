using Dwellers.Household.Domain.Entities.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Contracts.Responses.Household.Chat
{
        public record GetHouseholdConversationResponse(
        ICollection<DwellerMessage> AllMessages,
        Guid ConversationId);
}
