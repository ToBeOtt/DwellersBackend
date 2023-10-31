namespace Dwellers.Household.Domain.Entities
{
    public sealed class DwellerHouse
    {
        public Guid HouseId { get; set; }
        public Guid HouseholdCode { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public byte[]? HousePhoto { get; set; }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

        public DwellerHouse() { }
        public DwellerHouse(
            string name,
            string description)
        {
            HouseId = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.UtcNow;
            HouseholdCode = Guid.NewGuid();
        }
        private void UpdateHouse(DwellerHouse House)
        {
            throw new NotImplementedException();
        }
    }
}
    
