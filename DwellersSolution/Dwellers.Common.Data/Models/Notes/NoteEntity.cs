using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Data.Models.Notes
{
    public sealed class NoteEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<NoteHashtagEntity> NoteHashtagEntities { get; private set; }
        public int NotePriority { get; private set; }
        public int NoteStatus { get; private set; }
        public int NoteScope { get; private set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public DwellerUserEntity User { get; set; }

        // Allow editing and commenting
        public ICollection<NoteSubscriber> NoteSubscribers { get; set; }
        public ICollection<NoteComment> NoteComments { get; set; }

        public NoteEntity() { }

    }
}
