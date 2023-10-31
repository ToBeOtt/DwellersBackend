using Dwellers.Household.Application.Features.User;
using Dwellers.Household.Contracts.Requests;
using Mapster;

namespace DwellersApi.Common.Mapping.Household
{
    public class HouseholdMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<GetUserDetailsRequest, GetUserDetailsQuery>();
        }
    }
}


