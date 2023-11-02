namespace Dwellers.Common.Data.Models.Household
{
    public class HouseUserEntity
    {
        public Guid Id { get; set; }

        public Guid HouseId { get; set; }
        public HouseEntity House { get; set; }

        public string UserId { get; set; }
        public DwellerUserEntity User { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public HouseUserEntity() { }
        public HouseUserEntity(HouseEntity house, DwellerUserEntity user)
        {
            User = user;
            House = house;
        }
    }
}
