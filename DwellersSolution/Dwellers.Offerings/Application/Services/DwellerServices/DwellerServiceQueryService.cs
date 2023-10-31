using Dwellers.Common.DAL.Models.DwellerServices;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Dwellers.Offerings.Contracts.Interfaces.DwellerServices;
using Microsoft.Extensions.Logging;

namespace Dwellers.Offerings.Application.Services.DwellerServices
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

        public async Task<OfferingsServiceResponse<DwellerServiceEntity>> ProvideDwellerService(Guid houseId)
        {
            OfferingsServiceResponse<DwellerServiceEntity> response = new();

            var service = await _dwellerServiceQueryRepository.GetDwellerService(houseId);
            if (service == null)
            {
                _logger.LogInformation("No service could be found or registered");
                response.IsSuccess = false;
                response.ErrorMessage = "No service could be found or registered";
                return response;
            }

            response.IsSuccess = false;
            response.Data = service;
            return response;
        }
        public async Task<OfferingsServiceResponse<ICollection<DwellerServiceEntity>>> ProvideAllDwellerServices(Guid houseId)
        {
            OfferingsServiceResponse<ICollection<DwellerServiceEntity>> response = new();

            var serviceList = await _dwellerServiceQueryRepository.GetAllDwellerServices(houseId);
            if (serviceList == null)
            {
                _logger.LogInformation("No services found or registered");
                response.IsSuccess = false;
                response.ErrorMessage = "No services found or registered";
                return response;
            }

            response.IsSuccess = false;
            response.Data = serviceList;
            return response;
        }
    }
}
