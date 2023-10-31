namespace Dwellers.Common.DAL.Models.DwellerChat
{
    public class DwellerConversationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public ICollection<HouseConversationEntity> HouseConversations { get; set; }

        public DwellerConversationEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Created = DateTime.Now;
        }
    }
}
