﻿using Dwellers.Common.Data.Models.Notes;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems
{
    public interface INoteQueryRepository
    {
        Task<ICollection<NoteEntity>> GetNotes(Guid houseId);
        Task<ICollection<NoteEntity>> SortNotesByCategory(Guid houseId, int? noteCategory);
        Task<ICollection<NoteholderEntity>> GetNoteholders(Guid houseId);
        Task<NoteholderEntity> GetFullNoteholderById(Guid noteholderId, Guid HouseId);
        Task<NoteholderEntity> GetNoteholderById(Guid noteholderId);
        Task<NoteEntity> GetNoteById(Guid NoteId);
        Task<ICollection<NoteEntity>> GetNotesForNoteholder(Guid noteholderId);

        Task<ICollection<NoteEntity>> GetNewOrUpdatedNotes(Guid HouseId);
        Task<ICollection<NoteholderEntity>> GetNewOrUpdatedNoteholders(Guid HouseId);

    }
}