using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerServices;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerServices.Queries
{
    public record GetAllDwellerServicesQuery(
       Guid HouseId) : IRequest<GetAllDwellerServicesResult>;
    public record GetAllDwellerServicesResult(
        ICollection<DwellerService> DwellerServices);

    public class GetAllDwellerServicesQueryHandler : IRequestHandler<GetAllDwellerServicesQuery, GetAllDwellerServicesResult>
    {
        private readonly ILogger<GetAllDwellerServicesQueryHandler> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;

        public GetAllDwellerServicesQueryHandler(
            ILogger<GetAllDwellerServicesQueryHandler> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository
            )
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
        }

        public async Task<GetAllDwellerServicesResult> Handle(GetAllDwellerServicesQuery query, CancellationToken cancellationToken)
        {
            var serviceList = await _dwellerServiceQueryRepository.GetAllDwellerServices(query.HouseId);
            if (serviceList == null)
            {
                _logger.LogInformation("No services found or registered");
                throw new EntityNotFoundException("No services could be found");
            }

            return new GetAllDwellerServicesResult(
                DwellerServices: serviceList);
        }
    }
}
