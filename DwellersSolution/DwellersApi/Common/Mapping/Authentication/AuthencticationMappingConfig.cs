using Dwellers.Household.Application.Authentication.Commands.RegisterHouse;
using Dwellers.Household.Application.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Application.Authentication.Queries.Login;
using Dwellers.Household.Application.Features.Authentication.Commands.Register;
using Dwellers.Household.Application.Features.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Contracts.Requests;
using Dwellers.Household.Contracts.Responses.Authentication;
using Mapster;

namespace DwellersApi.Common.Mapping.Authentication
{
    public class AuthencticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<RegisterRequest, RegisterCommand>();
            
            config.NewConfig<RegisterHouseRequest, RegisterHouseCommand>();
            
            config.NewConfig<LoginRequest, LoginQuery>();
            

            // Result => Response
            config.NewConfig<RegisterResult, RegisterResponse>()
                .Map(dest => dest, src => src.User);

            config.NewConfig<RegisterHouseResult, RegisterHouseResponse>()
                .Map(dest => dest.Id, src => src.User.Id)
                .Map(dest => dest.Email, src => src.User.Email)
                .Map(dest => dest.Name, src => src.House.Name)
                .Map(dest => dest.Name, src => src.House.HouseholdCode);

            config.NewConfig<LoginResult, LoginResponse>()
                .Map(dest => dest, src => src.User);

        }
    }
}
