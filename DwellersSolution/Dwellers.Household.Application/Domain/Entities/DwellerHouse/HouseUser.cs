using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Domain.Entities.DwellerHouse
{
    public class HouseUser
    {
        public Guid Id { get; set; }

        public Guid HouseId { get; set; }
        public House House { get; set; }


        public string UserId { get; set; }
        public DwellerUser User { get; set; }

        public HouseUser() { }
        public HouseUser(House house, DwellerUser user)
        {
            User = user;
            House = house;
        }
    }
}
