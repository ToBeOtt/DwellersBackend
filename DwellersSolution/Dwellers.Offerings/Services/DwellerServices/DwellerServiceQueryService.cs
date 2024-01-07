using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

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

        public async Task<DwellerResponse<DwellerServiceEntity>> ProvideDwellerService(Guid houseId)
        {
            DwellerResponse<DwellerServiceEntity> response = new();

            var service = await _dwellerServiceQueryRepository.GetDwellerService(houseId);
            if (service == null)
                return await response.ErrorResponse
                           ("No service could be found or registered");

            return await response.SuccessResponse(service);
        }

        public async Task<DwellerResponse<ICollection<DwellerServiceEntity>>> ProvideAllDwellerServices(Guid houseId)
        {
            DwellerResponse<ICollection<DwellerServiceEntity>> response = new();

            var serviceList = await _dwellerServiceQueryRepository.GetAllDwellerServices(houseId);
            if (serviceList == null)
                return await response.ErrorResponse
                        ("No services found or registered.");

            return await response.SuccessResponse(serviceList);
        }
    }
}
