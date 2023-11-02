using Dwellers.Common.Persistance.NotesModule.Interfaces;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Application.Feature.Notes.Commands
{
    public record RemoveNoteCommand(
     Guid NoteId) : IRequest<RemoveNoteResult>;
    public record RemoveNoteResult(
     bool Outcome);

    public class RemoveNoteCommandHandler : IRequestHandler<RemoveNoteCommand, RemoveNoteResult>
    {
        private readonly ILogger<RemoveNoteCommandHandler> _logger;
        private readonly INoteCommandRepository _noteCommandRepository;
        private readonly INoteQueryRepository _noteQueryRepository;

        public RemoveNoteCommandHandler(
            ILogger<RemoveNoteCommandHandler> logger,
            INoteCommandRepository noteCommandRepository,
            INoteQueryRepository noteQueryRepository)
        {
            _logger = logger;
            _noteCommandRepository = noteCommandRepository;
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<RemoveNoteResult> Handle(RemoveNoteCommand cmd, CancellationToken cancellationToken)
        {
            var note = await _noteQueryRepository.GetNoteById(cmd.NoteId);
            if (note is null)
            {
                _logger.LogInformation("Note could not be found");
            }

            // delete note
            if (!await _noteCommandRepository.RemoveNote(note))
            {
                _logger.LogInformation("Could not delete record from database");
            }

            return new RemoveNoteResult(
                    Outcome: true);
        }
    }
}
