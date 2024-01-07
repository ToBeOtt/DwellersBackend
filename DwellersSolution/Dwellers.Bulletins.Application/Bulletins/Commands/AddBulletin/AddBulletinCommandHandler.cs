using Dwellers.Bulletins.Domain.Bulletins;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Bulletins.Application.Bulletins.Commands.AddBulletin
{
    public class AddBulletinCommandHandler : ICommandHandler<AddBulletinCommand, DwellerUnit>
    {
        private readonly ILogger<AddBulletinCommandHandler> _logger;
        private readonly IBulletinRepository _bulletinRepository;

        public AddBulletinCommandHandler(
            ILogger<AddBulletinCommandHandler> logger,
            IBulletinRepository bulletinRepository)
        {
            _logger = logger;
            _bulletinRepository = bulletinRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle
            (AddBulletinCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();
            try
            {
                var bulletin = Bulletin.BulletinPostFactory.CreateNewBulletin
                    (cmd.UserId, cmd.Title, cmd.Text, cmd.BulletinTags, cmd.BulletinPriority,
                     cmd.BulletinStatus, cmd.ChosenHouses, cmd.Visibility);

                if(! await _bulletinRepository.AddBulletin(bulletin))
                {
                    return await response.ErrorResponse
                        ("Bulletin could not be persisted");
                }

                return await response.SuccessResponse(new DwellerUnit());
            }
            catch (Exception ex)
            {
                return await response.ErrorResponse
                    ("Could not create bulletin");
            }

        }
    }
}

