using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;

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

        public async Task<ServiceResponse<DwellerItemEntity>> ProvideDwellerItem(Guid itemId)
        {
            ServiceResponse<DwellerItemEntity> response = new();

            var item = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (item == null)
                return await response.ErrorResponse(response, "No item could be found or registered", _logger);

            return await response.SuccessResponse(response, item);
        }

        public async Task<ServiceResponse<ICollection<DwellerItemEntity>>> ProvideAllDwellerItems
            (Guid houseId)
        {
            ServiceResponse<ICollection<DwellerItemEntity>> response = new();

            var itemList = await _dwellerItemQueryRepository.GetAllDwellerItems(houseId);
            if (itemList == null)
                return await response.ErrorResponse
                    (response, "No items found or registered", _logger, "Items null or not available from database.");

            return await response.SuccessResponse(response, itemList);
        }
    }
}
