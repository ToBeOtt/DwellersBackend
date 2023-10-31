using Dwellers.Common.DAL.Models.DwellerItems;
using Dwellers.Common.DAL.Models.DwellerServices;
using Dwellers.Common.DAL.Models.Notes;

namespace Dwellers.Common.DAL.Models.Household
{
    public sealed class HouseEntity
    {
        public Guid HouseId { get; set; }
        public Guid HouseholdCode { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public byte[]? HousePhoto { get; set; }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

        // Joins
        public ICollection<HouseUserEntity> HouseUsers { get; private set; }
        public ICollection<NoteEntity> Notes { get; set; }
        public ICollection<HouseNoteholderEntity> HouseNoteholders { get; private set; }

        public ICollection<BorrowedItemEntity> BorrowedItems { get; set; }
        public ICollection<ProvidedServiceEntity> ProvidedServices { get; set; }

        public HouseEntity() { }
        public HouseEntity(
            string name,
            string description)
        {
            HouseId = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.UtcNow;
            HouseholdCode = Guid.NewGuid();
        }
    }
}
