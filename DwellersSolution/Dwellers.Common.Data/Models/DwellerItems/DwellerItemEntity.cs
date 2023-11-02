using Dwellers.Common.Data.Models.Common.ValueObjects;

namespace Dwellers.Common.Data.Models.DwellerItems
{
    public sealed class DwellerItemEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public int ItemScope { get; private set; }
        public byte[]? ItemPhoto { get; set; }
        public bool ItemStatus { get; private set; }
        
        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public ICollection<BorrowedItemEntity> BorrowedItems { get; set; }

        public DwellerItemEntity() { }

    }
}
