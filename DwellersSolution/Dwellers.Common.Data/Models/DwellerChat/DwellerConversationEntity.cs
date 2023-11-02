using SharedKernel.Domain.DomainModels;

namespace Dwellers.Common.Data.Models.DwellerChat
{
    public class DwellerConversationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public ICollection<HouseConversationEntity> HouseConversations { get; set; }

        public DwellerConversationEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
