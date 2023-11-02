using Dwellers.Common.Data.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Data.Models.DwellerChat
{
    public class HouseConversationEntity
    {
        public Guid Id { get; set; }

        public HouseEntity House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerConversationEntity DwellerConversation { get; set; }
        public Guid ConversationId { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public HouseConversationEntity()
        {
            
        }
        public HouseConversationEntity(HouseEntity house, DwellerConversationEntity conversation)
        {
            Id = Guid.NewGuid();
            House = house;
            DwellerConversation = conversation;
        }

    }
}
