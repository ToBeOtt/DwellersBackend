using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Dwellers.Offerings.Application.Mappings.DwellerServices;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Dwellers.Offerings.Contracts.Commands;
using Dwellers.Offerings.Domain.Entities.DwellerServices;
using Microsoft.Extensions.Logging;

namespace Dwellers.Offerings.Application.Services.DwellerServices
{
    public class DwellerServiceCommandService
    {
        private readonly ILogger<DwellerServiceCommandService> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;
        private readonly IDwellerServiceCommandRepository _dwellerServiceCommandRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly DwellerServiceMappingService _mapping;

        public DwellerServiceCommandService(
            ILogger<DwellerServiceCommandService> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository,
            IDwellerServiceCommandRepository dwellerServiceCommandRepository,
            IHouseQueryRepository houseQueryRepository,
            DwellerServiceMappingService mapping)
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
            _dwellerServiceCommandRepository = dwellerServiceCommandRepository;
            _houseQueryRepository = houseQueryRepository;
            _mapping = mapping;
        }

        public async Task<OfferingsServiceResponse<bool>> CreateAndPersistService
            (AddDwellerServiceCommand cmd)
        {
            OfferingsServiceResponse<bool> response = new();

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                response.IsSuccess = false;
                response.ErrorMessage = "The item could not be added.";
                return response;
            }

            var dwellerService = new DomainDwellerService(cmd);
            var scopeSet = dwellerService.SetServiceScope(cmd.ServiceScope);
            if (!scopeSet.IsSuccess)
            {
                _logger.LogInformation(scopeSet.DomainErrorResponse);
                response.IsSuccess = false;
                response.ErrorMessage = scopeSet.DomainErrorResponse;
                return response;
            }

            var persistanceService = _mapping.MapToPersistence(dwellerService);

            if (!await _dwellerServiceCommandRepository.AddDwellerService(persistanceService))
            {
                _logger.LogInformation("Could not persist item to database");
                response.IsSuccess = false;
                response.ErrorMessage = "Could not persist item to database";
                return response;
            }

            var establishProvider = new ProvidedServiceEntity(house, persistanceService, true);

            if (!await _dwellerServiceCommandRepository.RegisterProvidedService(establishProvider))
            {
                _logger.LogInformation("Could not persist service-provider to database");
                response.IsSuccess = false;
                response.ErrorMessage = "Provider could not be established.";
                return response;
            }

            response.IsSuccess = true;
            return response;
        }

    }
}
