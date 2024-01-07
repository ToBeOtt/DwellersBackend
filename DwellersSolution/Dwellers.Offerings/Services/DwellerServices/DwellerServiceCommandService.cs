﻿using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Dwellers.Offerings.Contracts.Commands;
using Dwellers.Offerings.Domain.DwellerServices;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerServices
{
    public class DwellerServiceCommandService
    {
        private readonly ILogger<DwellerServiceCommandService> _logger;
        private readonly IDwellerServiceQueryRepository _dwellerServiceQueryRepository;
        private readonly IDwellerServiceCommandRepository _dwellerServiceCommandRepository;
        
        public DwellerServiceCommandService(
            ILogger<DwellerServiceCommandService> logger,
            IDwellerServiceQueryRepository dwellerServiceQueryRepository,
            IDwellerServiceCommandRepository dwellerServiceCommandRepository)
        {
            _logger = logger;
            _dwellerServiceQueryRepository = dwellerServiceQueryRepository;
            _dwellerServiceCommandRepository = dwellerServiceCommandRepository;
        }

        public async Task<DwellerResponse<bool>> CreateAndPersistService
            (AddDwellerServiceCommand cmd)
        {
            DwellerResponse<bool> response = new();

            var dwellerService = new DwellerService(cmd.Name, cmd.Description);

            var scopeSet = await dwellerService.SetServiceScope(cmd.ServiceScope);
            if (!scopeSet.IsSuccess)
                return await response.ErrorResponse
                        ("Something went wrong with adding the service.");


            if (!await _dwellerServiceCommandRepository.AddDwellerService(dwellerService))
                return await response.ErrorResponse
                        ("Something went wrong with adding the service.");

            var establishProvider = new ProvidedServiceEntity(cmd.DwellingId, dwellerService.Id, true);

            if (!await _dwellerServiceCommandRepository.RegisterProvidedService(establishProvider))
                return await response.ErrorResponse
                        ("Something went wrong with adding the service.");

            return await response.SuccessResponse();
        }
    }
}
