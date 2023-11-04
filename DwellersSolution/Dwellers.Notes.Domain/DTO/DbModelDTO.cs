using SharedKernel.Domain.DomainModels;

namespace Dwellers.Notes.Domain.DTO
{
    public class DbModelDTO : BaseEntity
    {
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;

        public List<string> NoteHashtagEntities { get; set; }
        public int? NotePriority { get; set; }
        public int? NoteStatus { get; set; }
        public int? NoteScope { get; set; }
    }
}


