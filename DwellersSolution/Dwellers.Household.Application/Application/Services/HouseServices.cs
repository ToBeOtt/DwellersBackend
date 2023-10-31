using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Services.Responses;

namespace Dwellers.Household.Application.Services
{
    public class HouseServices
    {
        private readonly IHouseQueryRepository _houseQueryRepository;

        public HouseServices(IHouseQueryRepository houseQueryRepository)
        {
            _houseQueryRepository = houseQueryRepository;
        }

        public async Task<HouseServiceResponse<Guid>> ServeGuidToAuthentication(string email)
        {
            HouseServiceResponse<Guid> response = new();

            var houseId = await _houseQueryRepository.GetHouseIdByEmail(email);

            if (houseId == null || houseId == Guid.Empty) 
            {
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;
            response.Data = houseId;
            return response;
        }
    }
}
