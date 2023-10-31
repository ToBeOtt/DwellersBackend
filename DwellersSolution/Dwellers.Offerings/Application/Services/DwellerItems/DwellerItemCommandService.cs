using Dwellers.Common.DAL.Models.DwellerItems;
using Dwellers.Common.DAL.Services.Interfaces;
using Dwellers.Offerings.Application.Mappings.DwellerItems;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Dwellers.Offerings.Contracts.Commands;
using Dwellers.Offerings.Contracts.Interfaces.DwellerItems;
using Dwellers.Offerings.Domain.Entities.DwellerItems;
using Microsoft.Extensions.Logging;

namespace Dwellers.Offerings.Application.Services.DwellerItems
{
    public class DwellerItemCommandService
    {
        private readonly ILogger<DwellerItemCommandService> _logger;
        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;
        private readonly ICommonHouseServices _commonHouseServices;
        private readonly DwellerItemMappingService _dwellerItemMappingService;

        public DwellerItemCommandService
            (ILogger<DwellerItemCommandService> logger,
            IDwellerItemCommandRepository dwellerItemCommandRepository,
            IDwellerItemQueryRepository dwellerItemQueryRepository,
            ICommonHouseServices commonHouseServices,
            DwellerItemMappingService dwellerItemMappingService)
        {
            _logger = logger;
            _dwellerItemCommandRepository = dwellerItemCommandRepository;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
            _commonHouseServices = commonHouseServices;
            _dwellerItemMappingService = dwellerItemMappingService;
        }

        public async Task<OfferingsServiceResponse<bool>> CreateAndPersistItem(AddDwellerItemCommand cmd)
        {
            OfferingsServiceResponse<bool> response = new();

            var house = await _commonHouseServices.GetHouseForOtherServicesById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                response.IsSuccess = false;
                response.ErrorMessage = "The item could not be added.";
                return response;
            }
            var dwellerItem = new DomainDwellerItem(cmd.Name, cmd.Desc);

            if(cmd.ItemScope != null)
                dwellerItem.SetItemScope(cmd.ItemScope);

            if (cmd.ItemPhoto != null)
                dwellerItem.SetItemPhoto(cmd.ItemPhoto);

            var dwellerItemPersistence = _dwellerItemMappingService.MapToPersistence(dwellerItem);

            if (!await _dwellerItemCommandRepository.AddDwellerItem(dwellerItemPersistence))
            {
                _logger.LogInformation("Could not persist item to database");
                response.IsSuccess = false;
                response.ErrorMessage = "Item could not be persisted";
                return response;
            }

            var establishOwnerShip = new BorrowedItemEntity(house, dwellerItemPersistence, true);

            if (!await _dwellerItemCommandRepository.RegisterItemStatus(establishOwnerShip))
            {
                _logger.LogInformation("Could not persist item-ownership to database");
                response.IsSuccess = false;
                response.ErrorMessage = "Ownership of item could not be established could not be persisted";
                return response;
            }

            response.IsSuccess = true;
            return response;
        }

        public async Task<OfferingsServiceResponse<bool>> DeleteDwellerItem(Guid itemId)
        {
            OfferingsServiceResponse<bool> response = new();

            var dwellerItem = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (dwellerItem == null)
            {
                _logger.LogInformation("Item could not be found.");
                response.IsSuccess = false;
                response.ErrorMessage = "Item could not be found.";
                return response;
            }
            if (!await _dwellerItemCommandRepository.RemoveDwellerItem(dwellerItem))
            {
                _logger.LogInformation("Could not delete item from database");
                response.IsSuccess = false;
                response.ErrorMessage = "Delete failed.";
                return response;
            }

            response.IsSuccess = true;
            return response;
        }
    }
}
