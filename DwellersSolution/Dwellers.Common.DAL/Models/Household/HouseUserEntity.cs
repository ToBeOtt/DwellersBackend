namespace Dwellers.Common.DAL.Models.Household
{
    public class HouseUserEntity
    {
        public Guid Id { get; set; }

        public Guid HouseId { get; set; }
        public HouseEntity House { get; set; }


        public string UserId { get; set; }
        public DwellerUserEntity User { get; set; }

        public HouseUserEntity() { }
        public HouseUserEntity(HouseEntity house, DwellerUserEntity user)
        {
            User = user;
            House = house;
        }
    }
}
