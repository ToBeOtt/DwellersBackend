using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Common.DAL.Models.DwellerServices
{
    public class ProvidedServiceEntity
    {
        public Guid Id { get; set; }

        public HouseEntity House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerServiceEntity Service { get; set; }
        public Guid ServiceId { get; set; }

        public bool IsProvider { get; set; }
        public bool Archived { get; private set; }

        public string? Note { get; set; }
        public DateTime Created { get; set; }
        public bool? ServiceReturned { get; set; }

        public ProvidedServiceEntity() { }
    }
}
