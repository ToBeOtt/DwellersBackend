namespace Dwellers.Chat.Domain.Entities
{
    public class DwellerConversation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public ICollection<HouseConversation> HouseConversations { get; set; }

        public DwellerConversation(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Created = DateTime.Now;
        }
    }
}
