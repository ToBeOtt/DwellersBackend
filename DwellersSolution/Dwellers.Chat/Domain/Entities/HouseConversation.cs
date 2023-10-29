namespace Dwellers.Chat.Domain.Entities
{
    public class HouseConversation
    {
        public Guid Id { get; set; }

        public Guid HouseId { get; set; }
        
        public DwellerConversation DwellerConversation { get; set; }
        public Guid DwellerConversationId { get; set; }


        public HouseConversation() { }
        public HouseConversation(Guid houseID, Guid dwellerConversationId)
        {
            HouseId = houseID;
            DwellerConversationId = dwellerConversationId;
        }
    }
}
