namespace Dwellers.Common.Data.Models.Notes
{
    public class NoteHashtagEntity
    {
        public Guid Id { get; set; }
        public string Name {  get; set; }

        public Guid NoteId { get; set; }
        public NoteEntity Note { get; set; }
    }
}
