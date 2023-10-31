namespace Dwellers.Common.DAL.Models.Notes
{
    public class NoteholderNotesEntity
    {
        public Guid Id { get; set; }

        public NoteholderEntity Noteholder { get; set; }
        public Guid NoteholderId { get; set; }

        public NoteEntity Note { get; set; }
        public Guid NoteId { get; set; }

        public NoteholderNotesEntity() { }
        public NoteholderNotesEntity(NoteholderEntity noteholder, NoteEntity note)
        {
            Noteholder = noteholder;
            Note = note;
        }
    }
}
