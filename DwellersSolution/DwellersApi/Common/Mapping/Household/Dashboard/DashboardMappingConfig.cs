using Dwellers.Household.Application.Features.Dashboard.Queries;
using Dwellers.Household.Contracts.Requests.Dashboard;
using Dwellers.Household.Contracts.Responses.Dashboard;
using Mapster;

namespace DwellersApi.Common.Mapping.Household.Dashboard
{
    public class DashboardMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<GetDashboardNotesRequest, GetDashboardNotesCommand>();

            // Result => Response
            config.NewConfig<GetDashboardNotesResult, GetDashboardNotesResponse>()
                .Map(dest => dest, src => src.Notes)
                .Map(dest => dest, src => src.Noteholders);
        }
    }
}
