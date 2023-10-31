using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Common.DAL.Models.DwellerItems
{
    public class BorrowedItemEntity
    {
        public Guid Id { get; set; }

        public HouseEntity House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerItemEntity Item { get; set; }
        public Guid ItemId { get; set; }

        public bool IsOwner { get; set; }
        public bool Archived { get; private set; }


        public string? Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Returned { get; set; }

        public BorrowedItemEntity() { }
        public BorrowedItemEntity(HouseEntity house, DwellerItemEntity item, bool isOwner)
        {
            House = house;
            Item = item;
            IsOwner = isOwner;
        }
        
    }
}
