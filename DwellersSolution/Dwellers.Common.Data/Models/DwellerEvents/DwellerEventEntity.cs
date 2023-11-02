using Dwellers.Common.Data.Models.Common.ValueObjects;
using Dwellers.Common.Data.Models.Household;
using System.ComponentModel.DataAnnotations;

namespace Dwellers.Common.Data.Models.DwellerEvents
{
    public sealed class DwellerEventEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public DateTime EventDate { get; private set; }
        public int EventScope { get; private set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellerUserEntity User { get; set; }
        public HouseEntity House { get; set; }

        public DwellerEventEntity()
        {
                
        }

    }
}
