using Dwellers.Bulletins.Domain.Bulletins;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using SharedKernel.Infrastructure.Configuration.Commands;
using static SharedKernel.Application.ServiceResponse.EmptySuccessfulCommandResponse;

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
        public async Task<ServiceResponse<DwellerUnit>> Handle
            (AddBulletinCommand cmd, CancellationToken cancellation)
        {
            ServiceResponse<DwellerUnit> response = new();
            try
            {
                var bulletin = Bulletin.BulletinPostFactory.CreateNewBulletin
                    (cmd.UserId, cmd.Title, cmd.Text, cmd.BulletinTags, cmd.BulletinPriority,
                     cmd.BulletinStatus, cmd.ChosenHouses, cmd.Visibility);

                if(! await _bulletinRepository.AddBulletin(bulletin))
                {
                    return await response.ErrorResponse
                        (response, "Bulletin could not be persisted", _logger);
                }

                return await response.SuccessResponse(response, new DwellerUnit());
            }
            catch (Exception ex)
            {
                return await response.ErrorResponse
                    (response, "Could not create bulletin", _logger, ex.Message);
            }

        }
    }
}

