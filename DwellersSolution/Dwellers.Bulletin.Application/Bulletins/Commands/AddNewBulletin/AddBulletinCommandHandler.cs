using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Dwellers.Common.Persistance.NotesModule.Interfaces;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Bulletin.Application.Bulletins.Commands.AddNewBulletin
{

    public record AddBulletinCommand(
      string Name,
      string Desc,
      string? NoteStatus,
      string? NotePriority,
      string? NoteScope,
      string? Category,
      Guid? NoteholderId,
      string UserId,
      Guid HouseId) : IRequest<AddBulletinResult>;

    public record AddBulletinResult(
      bool IsDone);


    public class AddBulletinCommandHandler : IRequestHandler<AddBulletinCommand, AddBulletinResult>
    {
        private readonly ILogger<AddBulletinCommandHandler> _logger;
        private readonly INoteCommandRepository _noteCommandRepository;
        private readonly INoteQueryRepository _noteQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;

        public AddBulletinCommandHandler(
            ILogger<AddBulletinCommandHandler> logger,
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
        public async Task<AddBulletinResult> Handle(AddBulletinCommand cmd, CancellationToken cancellationToken)
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

            var note = new BulletinEntity();
            note.User = user;
            note.House = house;


            if (!await _noteCommandRepository.AddNote(note))
            {
                _logger.LogInformation("Could not persist note to database");
            }

            return new AddBulletinResult(
                IsDone: true);

        }
    }
}
