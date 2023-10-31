using Dwellers.Common.DAL.Models.Common.ValueObjects;
using Dwellers.Common.DAL.Models.Household;
using System.ComponentModel.DataAnnotations;

namespace Dwellers.Common.DAL.Models.DwellerEvents
{
    public sealed class DwellerEventEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        [Required]
        public DateTime EventDate { get; private set; }
        [Required]
        public VisibilityScope EventScope { get; private set; }

        public bool Archived { get; private set; }
        public DateTime EventCreated { get; private set; }
        public DateTime? EventModified { get; private set; }

        public DwellerUserEntity User { get; set; }
        public HouseEntity House { get; set; }

      
    }
}
