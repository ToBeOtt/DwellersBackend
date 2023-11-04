using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Dwellers.Offerings.Contracts.Commands;
using Dwellers.Offerings.Domain.Entities.DwellerServices;
using Dwellers.Offerings.Mappings.DwellerServices;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerServices
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

        public async Task<ServiceResponse<bool>> CreateAndPersistService
            (AddDwellerServiceCommand cmd)
        {
            ServiceResponse<bool> response = new();

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
                return await response.ErrorResponse
                           (response, "Could not find household to which item belong.", _logger);

            var dwellerService = new DomainDwellerService(cmd);

            var scopeSet = dwellerService.SetServiceScope(cmd.ServiceScope);
            if (!scopeSet.IsSuccess)
                return await response.ErrorResponse
                        (response, "Something went wrong with adding the service.", _logger, scopeSet.DomainErrorMessage);

            var persistanceService = _mapping.MapToPersistence(dwellerService);

            if (!await _dwellerServiceCommandRepository.AddDwellerService(persistanceService))
                return await response.ErrorResponse
                        (response, "Something went wrong with adding the service.", _logger);

            var establishProvider = new ProvidedServiceEntity(house, persistanceService, true);

            if (!await _dwellerServiceCommandRepository.RegisterProvidedService(establishProvider))
                return await response.ErrorResponse
                        (response, "Something went wrong with adding the service.", _logger, scopeSet.DomainErrorMessage);

            return await response.SuccessResponse(response);
        }
    }
}
