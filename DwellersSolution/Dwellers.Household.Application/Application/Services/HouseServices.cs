using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Services
{
    public class HouseServices
    {
        private readonly IHouseQueryRepository _houseQueryRepository;

        public HouseServices(IHouseQueryRepository houseQueryRepository)
        {
            _houseQueryRepository = houseQueryRepository;
        }

        public async Task<HouseholdServiceResponse<Guid>> ServeGuidToAuthentication(string email)
        {
            HouseholdServiceResponse<Guid> response = new();

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
