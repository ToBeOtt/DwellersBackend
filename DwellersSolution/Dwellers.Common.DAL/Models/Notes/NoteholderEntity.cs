using Dwellers.Common.DAL.Models.Common.ValueObjects;
using Dwellers.Common.DAL.Models.DwellerChat.ValueObjects;

namespace Dwellers.Common.DAL.Models.Notes
{
    public sealed class NoteholderEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Category? Category { get; private set; }
        public VisibilityScope? NoteholderScope { get; private set; }

        public bool Archived { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

        public ICollection<HouseNoteholderEntity>? HouseNoteholders { get; set; }
        public ICollection<NoteholderNotesEntity>? NoteholderNotes { get; set; }

        public NoteholderEntity() { }
    }
}
