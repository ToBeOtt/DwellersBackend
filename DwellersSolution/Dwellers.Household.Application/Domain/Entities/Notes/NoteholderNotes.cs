namespace Dwellers.Household.Domain.Entities.Notes
{
    public class NoteholderNotes
    {
        public Guid Id { get; set; }

        public Noteholder Noteholder { get; set; }
        public Guid NoteholderId { get; set; }

        public Note Note { get; set; }
        public Guid NoteId { get; set; }

        public NoteholderNotes() { }
        public NoteholderNotes(Noteholder noteholder, Note note)
        {
            Noteholder = noteholder;
            Note = note;
        }
    }
}
