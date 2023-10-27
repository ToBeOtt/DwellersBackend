namespace Dwellers.Chat.Domain.Entities
{
    public class HouseConversation
    {
        public Guid Id { get; set; }

        public Guid HouseID { get; set; }

        public Guid DwellerConversationID { get; set; }
        public DwellerConversation DwellerConversation { get; set; }


        public HouseConversation() { }
        public HouseConversation(Guid houseID, Guid dwellerConversationID)
        {
            HouseID = houseID;
            DwellerConversationID = dwellerConversationID;
        }
    }
}
