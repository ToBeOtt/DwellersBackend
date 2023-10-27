using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.Exceptions;

namespace Dwellers.Household.Domain.Entities.DwellerItems
{
    public class BorrowedItem
    {
        public Guid Id { get; set; }

        public House House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerItem DwellerItem { get; set; }
        public Guid DwellerItemId { get; set; }

        public bool IsOwner { get; set; }
        public bool Archived { get; private set; }


        public string? Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Returned { get; set; }

        public BorrowedItem() { }
        public BorrowedItem(House house, DwellerItem item, bool isOwner)
        {
            Created = DateTime.Now;
            House = house;
            DwellerItem = item;
            IsOwner = isOwner;
        }

        public void SetArchived(bool isArchived)
        {
            if (IsOwner && isArchived)
            {
                throw new ForbiddenModificationException("An item cannot be archived by its owner.");
            }

            Archived = isArchived;
        }
    }
}
