using Dwellers.Bulletins.Domain.Bulletins;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.Bulletins.Application.Bulletins.Commands.DeleteBulletin
{
    public class DeleteBulletinCommandHandler : ICommandHandler<DeleteBulletinCommand, DwellerUnit>
    {
        private readonly ILogger<DeleteBulletinCommandHandler> _logger;
        private readonly IBulletinRepository _bulletinRepo;

        public DeleteBulletinCommandHandler(
            ILogger<DeleteBulletinCommandHandler> logger,
            IBulletinRepository bulletinRepo)
        {
            _logger = logger;
            _bulletinRepo = bulletinRepo;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle(DeleteBulletinCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var bulletin = await _bulletinRepo.GetById(cmd.Id);

            bulletin.ArchiveBulletin(bulletin);

            if (!await _bulletinRepo.DeleteBulletin(bulletin))
                return await response.ErrorResponse
                    ("Could not persist entity.");

            return await response.SuccessResponse(new DwellerUnit());
        }
    }
}
