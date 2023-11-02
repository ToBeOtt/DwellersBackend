using Dwellers.Common.Data.Models.Common.ValueObjects;
using Dwellers.Common.Data.Models.DwellerChat.ValueObjects;
using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Data.Models.Notes.ValueObjects;

namespace Dwellers.Common.Data.Models.Notes
{
    public sealed class NoteEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public int? NoteStatus { get; private set; }
        public int? NotePriority { get; private set; }
        public int? NoteScope { get; private set; }
        public int? Category { get; private set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellerUserEntity User { get; set; }
        public HouseEntity House { get; set; }
        public ICollection<NoteholderNotesEntity>? NoteholderNotes { get; set; }


        public NoteEntity() { }

    }
}
