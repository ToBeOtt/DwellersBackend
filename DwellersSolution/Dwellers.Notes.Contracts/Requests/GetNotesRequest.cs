namespace Dwellers.Notes.Contracts.Requests
{
    public record GetNotesRequest(
       Guid HouseId,
       int? NoteCategory
        );
}
