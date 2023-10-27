using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerServices;
using Dwellers.Household.Domain.Entities.Notes;

namespace Dwellers.Household.Domain.Entities.DwellerHouse
{
    public sealed class House
    {
        public Guid HouseId { get; set; }
        public Guid HouseholdCode { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public byte[]? HousePhoto { get; set; }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

        // Joins
        public ICollection<HouseUser> HouseUsers { get; private set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<HouseNoteholder> HouseNoteholders { get; private set; }
        public ICollection<HouseConversation> HouseConversations { get; set; }

        public ICollection<BorrowedItem> BorrowedItems { get; set; }
        public ICollection<ProvidedService> ProvidedServices { get; set; }

        public House() { }
        public House(
            string name,
            string description)
        {
            HouseId = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.UtcNow;
            HouseholdCode = Guid.NewGuid();
        }
        private void UpdateHouse(House House)
        {
            throw new NotImplementedException();
        }

    }
}
