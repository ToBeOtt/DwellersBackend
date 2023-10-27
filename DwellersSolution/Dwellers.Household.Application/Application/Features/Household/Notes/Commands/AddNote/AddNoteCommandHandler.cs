using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities.Notes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Notes.Commands.AddNote
{
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
            IHouseQueryRepository houseQueryRepository)
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
                throw new EntityNotFoundException("No user found");
            }

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                throw new EntityNotFoundException("No house found");
            }

            var note = new Note(cmd);
            note.User = user;
            note.House = house;

            if (cmd.NoteholderId == null)
            {
                if (!await _noteCommandRepository.AddNote(note))
                {
                    _logger.LogInformation("Could not persist note to database");
                    throw new PersistanceFailedException("Note could not be persisted");
                }

                return new AddNoteResult(
                   Note: note);
            }

            else
            {
                var noteholder = await _noteQueryRepository.GetNoteholderById((Guid)cmd.NoteholderId);
                if (noteholder is not null)
                {
                    var noteholdersNote = new NoteholderNotes(noteholder, note);
                    if (!await _noteCommandRepository.AddNoteholderNote(noteholdersNote))
                    {
                        _logger.LogInformation("Could not persist noteholderNote to database");
                        throw new PersistanceFailedException("NoteholdersNote could not be persisted");
                    }

                }

                if (!await _noteCommandRepository.AddNote(note))
                {
                    _logger.LogInformation("Could not persist note to database");
                    throw new PersistanceFailedException("Note could not be persisted");
                }

                return new AddNoteResult(
                   Note: note);
            }
        }
    }
}
