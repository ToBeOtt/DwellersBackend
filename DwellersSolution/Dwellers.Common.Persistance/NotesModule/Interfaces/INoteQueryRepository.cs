using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems
{
    public interface INoteQueryRepository
    {
        Task<ICollection<NoteEntity>> GetNotes(Guid houseId);
        Task<ICollection<NoteEntity>> SortNotesByCategory(Guid houseId, int? noteCategory);
        Task<NoteEntity> GetNoteById(Guid NoteId);
        Task<ICollection<NoteEntity>> GetNotesForNoteholder(Guid noteholderId);

        Task<ICollection<NoteEntity>> GetNewOrUpdatedNotes(Guid HouseId);

    }
}
