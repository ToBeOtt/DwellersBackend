using Dwellers.Common.DAL.Models.Common.ValueObjects;
using Dwellers.Common.DAL.Models.DwellerChat.ValueObjects;
using Dwellers.Common.DAL.Models.Household;
using Dwellers.Common.DAL.Models.Notes.ValueObjects;

namespace Dwellers.Common.DAL.Models.Notes
{
    public sealed class NoteEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public NoteStatus? NoteStatus { get; private set; }
        public NotePriority? NotePriority { get; private set; }
        public VisibilityScope? NoteScope { get; private set; }
        public Category? Category { get; private set; }

        public bool Archived { get; private set; }
        public DateTime NoteCreated { get; private set; }
        public DateTime? NoteModified { get; private set; }

        public DwellerUserEntity User { get; set; }
        public HouseEntity House { get; set; }
        public ICollection<NoteholderNotesEntity>? NoteholderNotes { get; set; }


        public NoteEntity() { }

    }
}
