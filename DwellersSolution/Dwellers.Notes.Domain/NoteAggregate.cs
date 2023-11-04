using Dwellers.Notes.Domain.DTO;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Notes.Domain
{
    public sealed class NoteAggregate : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; private set; } = null;
        public string? Description { get; private set; } = null;

        public NoteAggregate(DbModelDTO noteToInitiate) 
        {
            Id = Guid.NewGuid();
            Name = noteToInitiate.Name;
            Description = noteToInitiate.Description;

            if (noteToInitiate.NoteHashtagEntities != null || noteToInitiate.NoteStatus != null)
            {
                FilteringNotesEntity filteringNotesEntity = new
                (noteToInitiate.NoteHashtagEntities,
                 noteToInitiate.NoteStatus);
            }

            if (noteToInitiate.NoteScope != null)
            {
                var statusValue = noteToInitiate.NoteScope.Value;
                NoteSharing noteShare = new(statusValue);
            }


            if (noteToInitiate.NotePriority != null)
            {
                var priorityValue = noteToInitiate.NotePriority.Value;
                UrgencyOfNote noteUrgency = new(priorityValue);
            }
        }   
    }
}
