namespace Dwellers.Common.Data.Models.Notes
{
    public class NoteComment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Guid NoteId { get; set; }
        public NoteEntity Note { get; set; }
    }
}
