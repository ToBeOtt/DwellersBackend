using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Application.Contracts.Queries.Bulletins;
using Dwellers.Common.Application.Contracts.Queries.Dwellers;
using Dwellers.Common.Application.Contracts.Results.Bulletins;
using Dwellers.Common.Application.Contracts.Results.Dwellers;
using Dwellers.Common.Application.Interfaces.Bulletins;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;
using System.Security.Cryptography;

namespace Dwellers.Common.Application.Queries.Bulletins.GetDashboardBulletins
{
    public class GetDashboardBulletinsQueryHandler(ILogger<GetDashboardBulletinsQueryHandler> logger,
        IBulletinQueryRepository bulletinQueryRepository) :
        IQueryHandler<GetDashboardBulletinsQuery, GetDashboardBulletinsResult>
    {
        private readonly ILogger<GetDashboardBulletinsQueryHandler> _logger = logger;
        private readonly IBulletinQueryRepository _bulletinQueryRepository = bulletinQueryRepository;

        public async Task<DwellerResponse<GetDashboardBulletinsResult>> Handle
            (GetDashboardBulletinsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDashboardBulletinsResult> response = new();

            var listOfBulletins = await _bulletinQueryRepository.GetDashboardBulletinsAsync(query.Dwellingid);

            var listOfBulletinsDto = new List<DashboardBulletins>();
            foreach ( var bulletin in listOfBulletins )
            {
                var dashboardBulletin = new DashboardBulletins(bulletin.Title, 
                    bulletin.Dweller.Alias,
                    bulletin.Text,
                    bulletin.Scope.Visibility.ToString(),
                    bulletin.IsCreated.ToShortDateString(),
                    bulletin.IsModified.ToShortDateString());
                listOfBulletinsDto.Add(dashboardBulletin);
            }


            return await response.SuccessResponse(
                new(ListOfBulletinsForDashboard: listOfBulletinsDto));
        }
    }
}
