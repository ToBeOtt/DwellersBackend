using Dwellers.DwellerCore.Contracts.Queries;
using Dwellers.DwellerCore.Contracts.Result;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Interfaces;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Queries.GetDwellingByEmail
{
    public class GetDwellingByEmailQueryHandler :
        IQueryHandler<GetDwellingByEmailQuery, GetDwellingByEmailResult>
    {
        private readonly ILogger<GetDwellingByEmailQueryHandler> _logger;
        private readonly IDwellerRepository _dwellerRepository;
        private readonly IDwellerCoreQueries _dwellerCoreQueries;

        public GetDwellingByEmailQueryHandler
            (ILogger<GetDwellingByEmailQueryHandler> logger,
            IDwellerRepository dwellerRepository,
            IDwellerCoreQueries dwellerCoreQueries )
        {
            _logger = logger;
            _dwellerRepository = dwellerRepository;
            _dwellerCoreQueries = dwellerCoreQueries;
        }
        public async Task<DwellerResponse<GetDwellingByEmailResult>> Handle
            (GetDwellingByEmailQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellingByEmailResult> response = new();

            var dweller = await _dwellerRepository.GetDwellerByEmail(query.Email);

            var dwellerInhabitant = await _dwellerCoreQueries.GetDwellerInhabitantByDwellerId(dweller.Id);

            return await response.SuccessResponse(
                new GetDwellingByEmailResult(
                    DwellingId: Guid.NewGuid()
                    //DwellingId: dwellerInhabitant.DwellingId.Value
                    ));
        }
    }
}
