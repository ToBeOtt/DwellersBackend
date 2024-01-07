using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Common.Data.Models.DwellerEvents
{
    public sealed class DwellerEventEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public DateTime EventDate { get; private set; }
        public int EventScope { get; private set; }

        public bool IsArchived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public Dweller Dweller { get; set; }
        public Dwelling Dwelling { get; set; }

        public DwellerEventEntity()
        {
                
        }

    }
}
