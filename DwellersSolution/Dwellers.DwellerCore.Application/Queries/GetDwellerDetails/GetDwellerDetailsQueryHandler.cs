using Dwellers.DwellerCore.Contracts.Queries;
using Dwellers.DwellerCore.Contracts.Result;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Queries.GetDwellerDetails
{
    public class GetDwellerDetailsQueryHandler :
        IQueryHandler<GetDwellerDetailsQuery, GetDwellerDetailsResult>
    {
        private readonly ILogger<GetDwellerDetailsQueryHandler> _logger;
        private readonly IDwellerRepository _dwellerRepository;
        private readonly IDwellingRepository _dwellingRepository;

        public GetDwellerDetailsQueryHandler
            (ILogger<GetDwellerDetailsQueryHandler> logger,
            IDwellerRepository dwellerRepository,
            IDwellingRepository dwellingRepository)
        {
            _logger = logger;
            _dwellerRepository = dwellerRepository;
            _dwellingRepository = dwellingRepository;
        }
        public async Task<DwellerResponse<GetDwellerDetailsResult>> Handle
            (GetDwellerDetailsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellerDetailsResult> response = new();
           
            var dweller = await _dwellerRepository.GetDwellerById(query.DwellerId);
            if (dweller is null)
                return await response.ErrorResponse("Dweller details could not be fetched.");

            var dwelling = await _dwellingRepository.GetDwellingById(query.DwellingId);
            if (dwelling is null)
                return await response.ErrorResponse
                    ("Dwelling could not be fetched.");

            GetDwellerDetailsResult data = new(
                DwellerId: dweller.Id,
                DwellingId: dwelling.Id.Value
                );

            return await response.SuccessResponse(
                new( DwellerId: dweller.Id,
                     DwellingId: dwelling.Id.Value
                    ));
        }
    }
}
