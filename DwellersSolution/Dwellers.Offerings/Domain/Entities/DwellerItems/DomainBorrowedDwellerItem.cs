using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Offerings.Domain.Entities.DwellerItems
{
    public class DomainBorrowedDwellerItem
    {
        public Guid Id { get; set; }

        public DwellerHouse.DwellerHouse House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerItem DwellerItem { get; set; }
        public Guid DwellerItemId { get; set; }

        public bool IsOwner { get; set; }
        public bool Archived { get; private set; }


        public string? Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Returned { get; set; }

        public BorrowedDwellerItem() { }
        public BorrowedDwellerItem(DwellerHouse.DwellerHouse house, DwellerItem item, bool isOwner)
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
