using Dwellers.DwellerCore.Contracts.Commands;
using Dwellers.DwellerCore.Contracts.Result;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellerCore.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Commands.AttachDwellerToDwelling
{
    public class AttachDwellerToDwellingCommandHandler 
        : ICommandHandler<AttachDwellerToDwellingCommand, AttachDwellerToDwellingResult>
    {
        private readonly ILogger<AttachDwellerToDwellingCommandHandler> _logger;
        private readonly IDwellerRepository _dwellerRepository;
        private readonly IDwellingRepository _dwellingRepository;
        private readonly IDwellerCoreQueries _dwellerCoreQueries;

        public AttachDwellerToDwellingCommandHandler(
            ILogger<AttachDwellerToDwellingCommandHandler> logger,
            IDwellerRepository dwellerRepository,
            IDwellingRepository dwellingRepository,
            IDwellerCoreQueries dwellerCoreQueries)
        {
            _logger = logger;
            _dwellerRepository = dwellerRepository;
            _dwellingRepository = dwellingRepository;
            _dwellerCoreQueries = dwellerCoreQueries;
        }
        public async Task<DwellerResponse<AttachDwellerToDwellingResult>> Handle
            (AttachDwellerToDwellingCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<AttachDwellerToDwellingResult> response = new();

            var transaction = await _dwellingRepository.BeginTransactionAsync();
            try
            {
                var dweller = await _dwellerRepository.GetDwellerByEmail(cmd.Email);

                var dwelling = await _dwellerCoreQueries.GetDwellingByInvite(cmd.Invitation);

                var dwellingInhabitant = await DwellingInhabitant.DwellingInhabitantFactory.Create
                    (dweller.Id, dwelling.Id);

                await _dwellerRepository.AddDwellerInhabitant(dwellingInhabitant);

                await transaction.CommitAsync();

                return await response.SuccessResponse
                    (new AttachDwellerToDwellingResult(
                      Name: dwelling.GetName(),
                      Alias: dweller.GetAlias()));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return await response.ErrorResponse("Dweller could not be attached to dwelling.");
            }
        }
    }
}