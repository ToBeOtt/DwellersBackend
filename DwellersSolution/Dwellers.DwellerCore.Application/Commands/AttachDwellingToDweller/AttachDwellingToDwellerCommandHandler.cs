using Dwellers.DwellerCore.Contracts.Commands;
using Dwellers.DwellerCore.Contracts.Result;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellerCore.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Commands.AttachDwellingToDweller
{
    public class AttachDwellingToDwellerCommandHandler
        : ICommandHandler<AttachDwellingToDwellerCommand, AttachDwellingToDwellerResult>
    {
        private readonly ILogger<AttachDwellingToDwellerCommandHandler> _logger;
        private readonly IDwellerRepository _dwellerRepository;
        private readonly IDwellingRepository _dwellingRepository;

        public AttachDwellingToDwellerCommandHandler(
            ILogger<AttachDwellingToDwellerCommandHandler> logger,
            IDwellerRepository dwellerRepository,
            IDwellingRepository dwellingRepository)
        {
            _logger = logger;
            _dwellerRepository = dwellerRepository;
            _dwellingRepository = dwellingRepository;
        }
        public async Task<DwellerResponse<AttachDwellingToDwellerResult>> Handle
            (AttachDwellingToDwellerCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<AttachDwellingToDwellerResult> response = new();

            var transaction = await _dwellingRepository.BeginTransactionAsync();

            try
            {
                var dwelling = await Dwelling.DwellerHouseFactory.Create(cmd.Name, cmd.Description);
                if (dwelling == null)
                    throw new InvalidOperationException("Dwelling not found.");

                var dweller = await _dwellerRepository.GetDwellerByEmail(cmd.Email);
                if(dweller == null)
                    throw new InvalidOperationException("Dweller not found.");

                if(!await _dwellingRepository.AddDwelling(dwelling))
                    throw new InvalidOperationException("Dweller could not be added");

                var dwellingInhabitant = await DwellingInhabitant.DwellingInhabitantFactory.Create
                    (dweller.Id, dwelling.Id);

                if (!await _dwellerRepository.AddDwellerInhabitant(dwellingInhabitant))
                    throw new InvalidOperationException("Dweller could not be linked to dwelling.");

                await transaction.CommitAsync();

                return await response.SuccessResponse
                     (new AttachDwellingToDwellerResult(
                      Name: dwelling.GetName(),
                      DwellingId: dwelling.Id.Value));
            }

            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();

                return await response.ErrorResponse
                    ("Dwelling could not be coupled with dweller.");
            }
        }
    }
}
