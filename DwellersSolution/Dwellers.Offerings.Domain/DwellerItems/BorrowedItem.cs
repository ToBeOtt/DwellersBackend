using Dwellers.DwellerCore.Domain.Entities.Dwellings;

namespace Dwellers.Offerings.Domain.DwellerItems
{
    public class BorrowedItem
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }
        public Dwelling Dwelling { get; set; }
        public Guid DwellerItemId { get; set; }
        public DwellerItem DwellerItem { get; set; }    

        public bool IsOwner { get; set; }

        public string? Note { get; set; }
        public DateTime? Returned { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public BorrowedItem() { }
        public BorrowedItem(Dwelling dwelling, DwellerItem dwellerItem, bool isOwner)
        {
            Dwelling = dwelling;
            DwellerItem = dwellerItem;
            IsOwner = isOwner;
        }

    }
}
