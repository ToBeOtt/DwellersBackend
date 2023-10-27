using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Domain.Entities.Chat
{
    public class HouseConversation
    {
        public Guid Id { get; set; }

        public House House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerConversation DwellerConversation { get; set; }
        public Guid DwellerConversationId { get; set; }


        public HouseConversation() { }
        public HouseConversation(House house, DwellerConversation conversation)
        {
            House = house;
            DwellerConversation = conversation;
        }
    }
}
