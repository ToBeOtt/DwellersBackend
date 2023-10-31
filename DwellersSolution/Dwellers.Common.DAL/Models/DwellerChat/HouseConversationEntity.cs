using Dwellers.Common.DAL.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.DAL.Models.DwellerChat
{
    public class HouseConversationEntity
    {
        public Guid Id { get; set; }

        public Guid HouseId { get; set; }
        public HouseEntity House { get; set; }

        public DwellerConversationEntity Conversation { get; set; }
        public Guid ConversationId { get; set; }

        public HouseConversationEntity(HouseEntity house, DwellerConversationEntity conversation)
        {
            Id = Guid.NewGuid();
            House = house;
            Conversation = conversation;
        }

    }
}
