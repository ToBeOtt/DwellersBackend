using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Household.Services
{
    public class HouseServices
    {
        private readonly ILogger<HouseServices> _logger;
        private readonly IHouseQueryRepository _houseQuery;

        public HouseServices(
            ILogger<HouseServices> logger,
            IHouseQueryRepository houseQueryRepository)
        {
            _logger = logger;
            _houseQuery = houseQueryRepository;
        }

        public async Task<ServiceResponse<Guid>> ServeGuidToAuthentication(string email)
        {
            ServiceResponse<Guid> response = new();

            var houseId = await _houseQuery.GetHouseIdByEmail(email);

            if (houseId == null || houseId == Guid.Empty)
                return await response.ReturnError(response, "House did not exist", _logger);
           

            response.IsSuccess = true;
            response.Data = houseId;
            return await response.ReturnSuccess(response);
        }
    }
}
