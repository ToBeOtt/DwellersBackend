using Dwellers.Household.Application.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Application.Features.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Contracts.Requests;
using Dwellers.Household.Contracts.Responses.Authentication;
using Mapster;

namespace DwellersApi.Common.Mapping.Household
{
    public class HouseholdMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<GetUserDetailsRequest, GetUserDetailsQuery>();

            // Result => Response
            config.NewConfig<GetUserDetailsResult, GetUserDetailsResponse>()
                .Map(dest => dest, src => src.User)
                .Map(dest => dest, src => src.House);
        }
    }
}


