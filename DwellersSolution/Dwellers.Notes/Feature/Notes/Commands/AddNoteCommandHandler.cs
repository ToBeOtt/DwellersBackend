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
      Guid? NoteholderId,
      string UserId,
      Guid HouseId) : IRequest<AddNoteResult>;

    public record AddNoteResult(
      NoteEntity Note);


    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, AddNoteResult>
    {
        private readonly ILogger<AddNoteCommandHandler> _logger;
        private readonly INoteCommandRepository _noteCommandRepository;
        private readonly INoteQueryRepository _noteQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public AddNoteCommandHandler(
            ILogger<AddNoteCommandHandler> logger,
            INoteCommandRepository noteCommandRepository,
            INoteQueryRepository noteQueryRepository,
            IUserQueryRepository userQueryRepository,
            IHouseQueryRepository houseQueryRepository
)
        {
            _logger = logger;
            _noteCommandRepository = noteCommandRepository;
            _noteQueryRepository = noteQueryRepository;
            _userQueryRepository = userQueryRepository;
            _houseQueryRepository = houseQueryRepository;
        }
        public async Task<AddNoteResult> Handle(AddNoteCommand cmd, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(cmd.UserId);
            if (user is null)
            {
                _logger.LogInformation("Could not find entity in database");
            }

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
            }

            var note = new NoteEntity();
            note.User = user;
            note.House = house;

            if (cmd.NoteholderId == null)
            {
                if (!await _noteCommandRepository.AddNote(note))
                {
                    _logger.LogInformation("Could not persist note to database");
                }

                return new AddNoteResult(
                   Note: note);
            }

            else
            {
                var noteholder = await _noteQueryRepository.GetNoteholderById((Guid)cmd.NoteholderId);
                if (noteholder is not null)
                {
                    var noteholdersNote = new NoteholderNotesEntity(noteholder, note);
                    if (!await _noteCommandRepository.AddNoteholderNote(noteholdersNote))
                    {
                        _logger.LogInformation("Could not persist noteholderNote to database");
                    }

                }

                if (!await _noteCommandRepository.AddNote(note))
                {
                    _logger.LogInformation("Could not persist note to database");
                }

                return new AddNoteResult(
                   Note: note);
            }
        }
    }
}
