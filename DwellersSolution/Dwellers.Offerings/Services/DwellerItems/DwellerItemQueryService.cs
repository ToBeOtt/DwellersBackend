using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Microsoft.Extensions.Logging;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Services.DwellerItems
{
    public class DwellerItemQueryService
    {
        private readonly ILogger<DwellerItemQueryService> _logger;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;

        public DwellerItemQueryService(
            ILogger<DwellerItemQueryService> logger,
            IDwellerItemQueryRepository dwellerItemQueryRepository)
        {
            _logger = logger;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
        }

        public async Task<DwellerResponse<DwellerItemEntity>> ProvideDwellerItem(Guid itemId)
        {
            DwellerResponse<DwellerItemEntity> response = new();

            var item = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (item == null)
                return await response.ErrorResponse("No item could be found or registered");

            return await response.SuccessResponse(item);
        }

        public async Task<DwellerResponse<ICollection<DwellerItemEntity>>> ProvideAllDwellerItems
            (Guid houseId)
        {
            DwellerResponse<ICollection<DwellerItemEntity>> response = new();

            var itemList = await _dwellerItemQueryRepository.GetAllDwellerItems(houseId);
            if (itemList == null)
                return await response.ErrorResponse
                    ("No items found or registered");

            return await response.SuccessResponse(itemList);
        }
    }
}
