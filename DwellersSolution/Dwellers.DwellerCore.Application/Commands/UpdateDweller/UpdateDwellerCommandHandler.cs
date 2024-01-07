using Dwellers.DwellerCore.Contracts.Commands;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.ServiceResponse;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace Dwellers.DwellerCore.Commands.UpdateDweller
{
    public class SetDwellerProfilePhotoCommandHandler : ICommandHandler<SetDwellerProfilePhotoCommand, DwellerUnit>
    {
        private readonly ILogger<SetDwellerProfilePhotoCommandHandler> _logger;
        private readonly IDwellerRepository _dwellerRepository;

        public SetDwellerProfilePhotoCommandHandler(
            ILogger<SetDwellerProfilePhotoCommandHandler> logger,
            IDwellerRepository dwellerRepository)
        {
            _logger = logger;
            _dwellerRepository = dwellerRepository;
        }
        public async Task<DwellerResponse<DwellerUnit>> Handle
            (SetDwellerProfilePhotoCommand cmd, CancellationToken cancellation)
        {
            DwellerResponse<DwellerUnit> response = new();

            var dweller = await _dwellerRepository.GetDwellerById(cmd.DwellerId);
            if (dweller is null)
                return await response.ErrorResponse
                    ("User could not be found.");

            if(await dweller.SetProfilePhoto(cmd.DwellerPhoto))
                return await response.SuccessResponse(new DwellerUnit());

            else
                return await response.ErrorResponse
                  ("An error occurred while updating the profile-photo.");

        }
    }
}
