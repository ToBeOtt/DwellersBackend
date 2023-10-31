using Dwellers.Common.DAL.Models.DwellerItems;
using Dwellers.Common.DAL.Services.Interfaces;
using Dwellers.Offerings.Application.Interfaces.DwellerItems;
using Dwellers.Offerings.Application.Mappings.DwellerItems;
using Dwellers.Offerings.Application.Services.DwellerItems.Commands;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Dwellers.Offerings.Domain.Entities.DwellerItems;
using Microsoft.Extensions.Logging;

namespace Dwellers.Offerings.Application.Services.DwellerItems
{
    public class DwellerItemCommandService
    {
        private readonly ILogger<DwellerItemCommandService> _logger;
        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;
        private readonly ICommonHouseServices _commonHouseServices;
        private readonly DwellerItemMappingService _dwellerItemMappingService;

        public DwellerItemCommandService
            (ILogger<DwellerItemCommandService> logger,
            IDwellerItemCommandRepository dwellerItemCommandRepository,
            ICommonHouseServices commonHouseServices,
            DwellerItemMappingService dwellerItemMappingService)
        {
            _logger = logger;
            _dwellerItemCommandRepository = dwellerItemCommandRepository;
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
    }
}
