using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Notes.Contracts.Responses
{
    public record GetNoteholderResponse(
        NoteholderEntity Noteholder,
        ICollection<NoteEntity> Notes);
}
