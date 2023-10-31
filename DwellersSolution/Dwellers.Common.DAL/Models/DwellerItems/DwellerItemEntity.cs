using Dwellers.Common.DAL.Models.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.DAL.Models.DwellerItems
{
    public sealed class DwellerItemEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ItemScope { get; private set; }
        public byte[]? ItemPhoto { get; set; }
        public bool ItemStatus { get; private set; }
        public DateTime? DateAdded { get; private set; }

        public ICollection<BorrowedItemEntity> BorrowedItems { get; set; }

        public DwellerItemEntity() { }

        public DwellerItemEntity(
            Guid id,
            string name, 
            string desc, 
            bool itemStatus,
            VisibilityScope visibilityScope,
            DateTime? dateAdded,
            byte[]? photo)
        {
            Id = id;
            Name = name;
            Description = desc;
            ItemStatus = itemStatus;
            ItemScope = visibilityScope;
            DateAdded = dateAdded;
            if(ItemPhoto != null)
            {
                ItemPhoto = photo;
            }
         }
    }
}
