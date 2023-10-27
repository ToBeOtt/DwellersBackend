namespace Dwellers.Household.Contracts.Requests.Household.Notes
{
    public record GetNotesRequest(
       Guid HouseId,
       int? NoteCategory
        );
}
