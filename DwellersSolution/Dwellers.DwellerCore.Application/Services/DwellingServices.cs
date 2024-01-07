using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Services
{
    public class DwellingServices
    {
        private readonly ILogger<DwellingServices> _logger;
        private readonly IDwellingRepository _dwellingRepository;

        public DwellingServices(
            ILogger<DwellingServices> logger,
            IDwellingRepository dwellingRepository)
        {
            _logger = logger;
            _dwellingRepository = dwellingRepository;
        }

        public async Task<DwellerResponse<Guid>> ServeGuidToAuthentication(string email)
        {
            DwellerResponse<Guid> response = new();

            var dwelling = await _dwellingRepository.GetDwellingByEmail(email);

            if (dwelling == null || dwelling.Id.Value == Guid.Empty)
                return await response.ErrorResponse("Dwelling does not exist");
           
            return await response.SuccessResponse(dwelling.Id.Value);
        }
    }
}
