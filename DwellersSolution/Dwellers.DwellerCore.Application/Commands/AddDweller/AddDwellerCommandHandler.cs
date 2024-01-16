using Dwellers.DwellerCore.Contracts.Commands;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.DwellerCore.Commands.AddDweller
{
    public class AddDwellerCommandHandler : ICommandHandler<AddDwellerCommand, DwellerUnit>
    {
        private readonly ILogger<AddDwellerCommandHandler> _logger;
        private readonly IDwellerRepository _dwellerRepository;

        public AddDwellerCommandHandler(
            ILogger<AddDwellerCommandHandler> logger,
            IDwellerRepository dwellerRepository)
        {
            _logger = logger;
            _dwellerRepository = dwellerRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle
            (AddDwellerCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var dweller = await Dweller.DwellerFactory.Create
                (cmd.DwellerId, cmd.Alias, cmd.Email);

            if(!await _dwellerRepository.AddDweller(dweller))
                return await response.SuccessResponse(new DwellerUnit());

            else
            return await response.ErrorResponse
                   ("Could not add dweller");
        }
    }
}
