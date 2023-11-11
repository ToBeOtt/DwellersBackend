using SharedKernel.Domain.DomainModels;

namespace Dwellers.Notes.Domain
{
    internal class NoteInteractions : BaseEntity
    {
        public string Title { get; private set; }
        public string Text { get; private set; }

        // Förmåga att kommentera NOTE?

        // Event notifying all within scope of comment.
    }
}
