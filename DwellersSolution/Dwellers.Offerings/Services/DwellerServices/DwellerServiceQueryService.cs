using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerServices
{
    public class DwellerServiceQueryService
    {
        private readonly ILogger<DwellerServiceQueryService> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;

        public DwellerServiceQueryService(
            ILogger<DwellerServiceQueryService> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository)
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
        }

        public async Task<ServiceResponse<DwellerServiceEntity>> ProvideDwellerService(Guid houseId)
        {
            ServiceResponse<DwellerServiceEntity> response = new();

            var service = await _dwellerServiceQueryRepository.GetDwellerService(houseId);
            if (service == null)
                return await response.ErrorResponse
                           (response, "No service could be found or registered", _logger);

            return await response.SuccessResponse(response, service);
        }

        public async Task<ServiceResponse<ICollection<DwellerServiceEntity>>> ProvideAllDwellerServices(Guid houseId)
        {
            ServiceResponse<ICollection<DwellerServiceEntity>> response = new();

            var serviceList = await _dwellerServiceQueryRepository.GetAllDwellerServices(houseId);
            if (serviceList == null)
                return await response.ErrorResponse
                        (response, "No services found or registered.", _logger);

            return await response.SuccessResponse(response, serviceList);
        }
    }
}
