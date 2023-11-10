using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Common.Data.Models.Household
{
    public sealed class HouseEntity
    {
        public Guid Id { get; set; }
        public Guid HouseholdCode { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public byte[]? HousePhoto { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        // Joins
        public ICollection<HouseUserEntity> HouseUsers { get; private set; }
        public ICollection<NoteEntity> Notes { get; set; }
 
        public ICollection<BorrowedItemEntity> BorrowedItems { get; set; }
        public ICollection<ProvidedServiceEntity> ProvidedServices { get; set; }

        public HouseEntity() { }
        public HouseEntity(
            string name,
            string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            HouseholdCode = Guid.NewGuid();
        }
    }
}
