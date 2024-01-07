namespace Dwellers.Common.Data.Models.DwellerItems
{
    public class BorrowedItemEntity
    {
        public Guid Id { get; set; }

        public Guid DwellingId { get; set; }
        public Guid ItemId { get; set; }

        public bool IsOwner { get; set; }

        public string? Note { get; set; }
        public DateTime? Returned { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public BorrowedItemEntity() { }
        public BorrowedItemEntity(Guid dwellingId, Guid itemId, bool isOwner)
        {
            DwellingId = dwellingId;
            ItemId = itemId;
            IsOwner = isOwner;
        }
        
    }
}
