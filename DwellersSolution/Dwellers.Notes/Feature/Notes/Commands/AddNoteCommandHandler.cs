using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Dwellers.Common.Persistance.NotesModule.Interfaces;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Feature.Notes.Commands
{

    public record AddNoteCommand(
      string Name,
      string Desc,
      string? NoteStatus,
      string? NotePriority,
      string? NoteScope,
      string? Category,
      string UserId) : IRequest<AddNoteResult>;

    public record AddNoteResult(
      NoteEntity Note);


    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, AddNoteResult>
    {
        private readonly ILogger<AddNoteCommandHandler> _logger;
        private readonly INoteCommandRepository _noteCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public AddNoteCommandHandler(
            ILogger<AddNoteCommandHandler> logger,
            INoteCommandRepository noteCommandRepository,
            IUserQueryRepository userQueryRepository
)
        {
            _logger = logger;
            _noteCommandRepository = noteCommandRepository;
            _userQueryRepository = userQueryRepository;
        }
        public async Task<AddNoteResult> Handle(AddNoteCommand cmd, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(cmd.UserId);
            if (user is null)
            {
                _logger.LogInformation("Could not find entity in database");
            }

            var note = new NoteEntity();
            note.User = user;

            if (!await _noteCommandRepository.AddNote(note))
            {
                _logger.LogInformation("Could not persist note to database");
            }

            return new AddNoteResult(
                Note: note);    
        }
    }
}
