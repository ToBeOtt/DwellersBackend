using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Dwellers.Offerings.Contracts.Commands;
using Dwellers.Offerings.Domain.Entities.DwellerItems;
using Dwellers.Offerings.Mappings.DwellerItems;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerItems
{
    public class DwellerItemCommandService
    {
        private readonly ILogger<DwellerItemCommandService> _logger;
        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly DwellerItemMappingService _dwellerItemMappingService;

        public DwellerItemCommandService
            (ILogger<DwellerItemCommandService> logger,
            IDwellerItemCommandRepository dwellerItemCommandRepository,
            IDwellerItemQueryRepository dwellerItemQueryRepository,
            IHouseQueryRepository houseQueryRepository,
            DwellerItemMappingService dwellerItemMappingService)
        {
            _logger = logger;
            _dwellerItemCommandRepository = dwellerItemCommandRepository;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
            _houseQueryRepository = houseQueryRepository;
            _dwellerItemMappingService = dwellerItemMappingService;
        }

        public async Task<ServiceResponse<bool>> CreateAndPersistItem(AddDwellerItemCommand cmd)
        {
            ServiceResponse<bool> response = new();

            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
                return await response.ErrorResponse
                    (response, "The item could not be added.", _logger, "Could not find entity in database.");

            var dwellerItem = new DomainDwellerItem(cmd.Name, cmd.Desc);

            if (cmd.ItemScope != null)
            {
                var setScope = await dwellerItem.SetItemScope(cmd.ItemScope);
                if (!setScope.IsSuccess)
                    return await response.ErrorResponse
                        (response, "Could not set item scope.", _logger, setScope.DomainErrorMessage);
            }

            if (cmd.ItemPhoto != null)
            {
                var photoResult = await dwellerItem.SetItemPhoto(cmd.ItemPhoto);
                if (!photoResult.IsSuccess)
                    return await response.ErrorResponse
                        (response, "Could not add item-photo.", _logger, photoResult.DomainErrorMessage);
            }

            var dwellerItemPersistence = _dwellerItemMappingService.MapToPersistence(dwellerItem);

            if (!await _dwellerItemCommandRepository.AddDwellerItem(dwellerItemPersistence))
                return await response.ErrorResponse
                          (response, "Item could not be added to database.", _logger);

            var establishOwnerShip = new BorrowedItemEntity(house, dwellerItemPersistence, true);

            if (!await _dwellerItemCommandRepository.RegisterItemStatus(establishOwnerShip))
                return await response.ErrorResponse
                            (response, "Ownership of item could not be established.", _logger);

            return await response.SuccessResponse(response);
        }

        public async Task<ServiceResponse<bool>> DeleteDwellerItem(Guid itemId)
        {
            ServiceResponse<bool> response = new();

            var dwellerItem = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (dwellerItem == null)
                return await response.ErrorResponse
                        (response, "Item could not be found.", _logger);


            if (!await _dwellerItemCommandRepository.RemoveDwellerItem(dwellerItem))
                return await response.ErrorResponse
                         (response, "Could not delete item from database.", _logger);

            return await response.SuccessResponse(response);
        }
    }
}
