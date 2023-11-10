using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.NotesModule.Interfaces;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Dwellers.Notes.Domain.DTO;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes
{
    public class NoteService
    {
        private readonly ILogger<NoteService> _logger;
        private readonly INoteCommandRepository _noteCommand;
        private readonly INoteQueryRepository _noteQuery;

        public NoteService(
            ILogger<NoteService> logger,
            INoteCommandRepository noteCommand,
            INoteQueryRepository noteQuery)
        {
            _logger = logger;
            _noteCommand = noteCommand;
            _noteQuery = noteQuery;
        }

        public async Task<NoteEntity> FetchNoteEntityByUser(Guid noteId)
        {
            var note = await _noteQuery.GetNoteById(noteId);
            DbModelDTO dTO = new DbModelDTO();
            return note;
        }
    }
}
