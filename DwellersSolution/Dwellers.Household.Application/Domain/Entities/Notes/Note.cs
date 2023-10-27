using Dwellers.Household.Application.Features.Household.Notes.Commands.AddNote;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.ValueObjects;

namespace Dwellers.Household.Domain.Entities.Notes
{
    public sealed class Note
    {
        public Guid NoteId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public NoteStatus? NoteStatus { get; private set; }
        public NotePriority? NotePriority { get; private set; }
        public VisibilityScope? NoteScope { get; private set; }
        public Category? Category { get; private set; }

        public bool Archived { get; private set; }
        public DateTime NoteCreated { get; private set; }
        public DateTime? NoteModified { get; private set; }

        public DwellerUser User { get; set; }
        public House House { get; set; }
        public ICollection<NoteholderNotes>? NoteholderNotes { get; set; }


        public Note() { }

        public Note(AddNoteCommand cmd)
        {
            AssembleNote(cmd);
        }

        private void AssembleNote(AddNoteCommand cmd)
        {
            NoteId = Guid.NewGuid();
            Name = cmd.Name;
            Description = cmd.Desc;
            Archived = false;
            NoteCreated = DateTime.Now;

            if (Enum.TryParse(cmd.NoteStatus, out NoteStatus status))
            {
                NoteStatus = status;
            }
            else NoteStatus = null;

            if (Enum.TryParse(cmd.NotePriority, out NotePriority priority))
            {
                NotePriority = priority;
            }
            else NotePriority = null;

            if (Enum.TryParse(cmd.NoteScope, out VisibilityScope scope))
            {
                NoteScope = scope;
            }
            else NoteScope = null;
        }
    }
}
