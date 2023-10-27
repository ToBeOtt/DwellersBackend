using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Domain.Entities.Notes
{
    public class HouseNoteholder
    {
        public Guid Id { get; set; }

        public House House { get; set; }
        public Guid HouseId { get; set; }

        public Noteholder Noteholder { get; set; }
        public Guid NoteholderId { get; set; }

        public HouseNoteholder() { }
        public HouseNoteholder(House house, Noteholder noteholder)
        {
            House = house;
            Noteholder = noteholder;
        }

    }
}
