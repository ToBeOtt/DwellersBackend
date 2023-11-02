using Dwellers.Common.Data.Models.Common.ValueObjects;
using Dwellers.Common.Data.Models.DwellerChat.ValueObjects;

namespace Dwellers.Common.Data.Models.Notes
{
    public sealed class NoteholderEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int? Category { get; private set; }
        public int? NoteholderScope { get; private set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public ICollection<HouseNoteholderEntity>? HouseNoteholders { get; set; }
        public ICollection<NoteholderNotesEntity>? NoteholderNotes { get; set; }

        public NoteholderEntity() { }
    }
}
