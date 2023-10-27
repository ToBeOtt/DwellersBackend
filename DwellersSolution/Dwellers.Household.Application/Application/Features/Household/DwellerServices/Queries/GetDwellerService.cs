using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Domain.Entities.DwellerServices;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerServices.Queries
{
    public record GetDwellerServiceQuery(
        Guid HouseId) : IRequest<GetDwellerServiceResult>;
    public record GetDwellerServiceResult(
        DwellerService DwellerService);

    public class GetDwellerServiceQueryHandler : IRequestHandler<GetDwellerServiceQuery, GetDwellerServiceResult>
    {
        private readonly ILogger<GetDwellerServiceQueryHandler> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;

        public GetDwellerServiceQueryHandler(
            ILogger<GetDwellerServiceQueryHandler> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository
            )
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
        }

        public async Task<GetDwellerServiceResult> Handle(GetDwellerServiceQuery query, CancellationToken cancellationToken)
        {
            var service = await _dwellerServiceQueryRepository.GetDwellerService(query.HouseId);
            if (service == null)
            {
                _logger.LogInformation("No service could be found or registered");
                throw new EntityNotFoundException("No service could be found");
            }

            return new GetDwellerServiceResult(
                DwellerService: service);
        }
    }
}
