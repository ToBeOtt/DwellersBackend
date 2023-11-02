using Dwellers.Common.Data.Models.Common.ValueObjects;
using Dwellers.Common.Data.Models.DwellerChat.ValueObjects;
using Dwellers.Common.Data.Models.Notes.ValueObjects;
using Dwellers.Notes.Application.Feature.Notes.Commands;

namespace Dwellers.Notes.Domain
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
