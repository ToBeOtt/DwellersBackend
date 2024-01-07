using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.Offerings.Contracts.Commands;
using Dwellers.Offerings.Domain.DwellerItems;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerItems
{
    public class DwellerItemCommandService
    {
        private readonly ILogger<DwellerItemCommandService> _logger;
        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;
        private readonly IDwellingRepository _dwellingRepository;

        public DwellerItemCommandService
            (ILogger<DwellerItemCommandService> logger,
            IDwellerItemCommandRepository dwellerItemCommandRepository,
            IDwellerItemQueryRepository dwellerItemQueryRepository,
            IDwellingRepository dwellingRepository)
        {
            _logger = logger;
            _dwellerItemCommandRepository = dwellerItemCommandRepository;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
            _dwellingRepository = dwellingRepository;
        }

        public async Task<DwellerResponse<bool>> CreateAndPersistItem(AddDwellerItemCommand cmd)
        {
            DwellerResponse<bool> response = new();

            //var house = await _dwellingRepository.GetDwellingById(cmd.DwellingId);
            //if (house is null)
            //    return await response.ErrorResponse
            //        (response, "The item could not be added.", _logger, "Could not find entity in database.");

            var dwellerItem = new DwellerItem(cmd.Name, cmd.Desc);

            if (cmd.ItemScope != null)
            {
                var setScope = await dwellerItem.SetItemScope(cmd.ItemScope);
                if (!setScope.IsSuccess)
                    return await response.ErrorResponse
                        ("Could not set item scope.");
            }

            if (cmd.ItemPhoto != null)
            {
                var photoResult = await dwellerItem.SetItemPhoto(cmd.ItemPhoto);
                if (!photoResult.IsSuccess)
                    return await response.ErrorResponse
                        ("Could not add item-photo.");
            }


            if (!await _dwellerItemCommandRepository.AddDwellerItem(dwellerItem))
                return await response.ErrorResponse
                          ("Item could not be added to database.");

            var establishOwnerShip = new BorrowedItemEntity(cmd.DwellingId, dwellerItem.Id, true);

            if (!await _dwellerItemCommandRepository.RegisterItemStatus(establishOwnerShip))
                return await response.ErrorResponse
                            ("Ownership of item could not be established.");

            return await response.SuccessResponse();
        }

        public async Task<DwellerResponse<bool>> DeleteDwellerItem(Guid itemId)
        {
            DwellerResponse<bool> response = new();

            var dwellerItem = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (dwellerItem == null)
                return await response.ErrorResponse
                        ("Item could not be found.");


            if (!await _dwellerItemCommandRepository.RemoveDwellerItem(dwellerItem))
                return await response.ErrorResponse
                         ("Could not delete item from database.");

            return await response.SuccessResponse();
        }
    }
}
