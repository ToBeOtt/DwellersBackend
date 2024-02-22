using Dwellers.Common.Application.Contracts.Queries.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Dwellers.Common.Application.Interfaces;
using Dwellers.Common.Application.Interfaces.DwellerCore.Dwellers;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;


namespace Dwellers.Common.Application.Queries.Dwellings.GetDwellingByEmail
{
    public class GetDwellingByEmailQueryHandler :
        IQueryHandler<GetDwellingByEmailQuery, GetDwellingByEmailResult>
    {
        private readonly ILogger<GetDwellingByEmailQueryHandler> _logger;
        private readonly IDwellerQueryRepository _dwellerQueryRepository;

        public GetDwellingByEmailQueryHandler
            (ILogger<GetDwellingByEmailQueryHandler> logger,
            IDwellerQueryRepository dwellerQueryRepository)
        {
            _logger = logger;
            _dwellerQueryRepository = dwellerQueryRepository;
        }
        public async Task<DwellerResponse<GetDwellingByEmailResult>> Handle
            (GetDwellingByEmailQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellingByEmailResult> response = new();

            var dweller = await _dwellerQueryRepository.GetDwellerByEmailAsync(query.Email);

            //var dwellerInhabitant = await _dwellerQueryRepository.GetDwellerInhabitantByDwellerId(dweller.Id);

            return await response.SuccessResponse(
                new GetDwellingByEmailResult(
                    DwellingId: Guid.NewGuid()));
        }
    }
}
