using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Dwellers.Offerings.Application.Services.ServiceResponses;
using Microsoft.Extensions.Logging;

namespace Dwellers.Offerings.Application.Services.DwellerItems
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

        public async Task<OfferingsServiceResponse<DwellerItemEntity>> ProvideDwellerItem(Guid itemId)
        {
            OfferingsServiceResponse<DwellerItemEntity> response = new();

            var item = await _dwellerItemQueryRepository.GetDwellerItem(itemId);
            if (item == null)
            {
                _logger.LogInformation("No item could be found or registered");
                response.IsSuccess = false;
                response.ErrorMessage = "The requested item could be found";
                return response;
            }
            response.IsSuccess = true;
            response.Data = item;
            return response;
        }

        public async Task<OfferingsServiceResponse<ICollection<DwellerItemEntity>>> ProvideAllDwellerItems
            (Guid houseId)
        {
            OfferingsServiceResponse<ICollection<DwellerItemEntity>> response = new();

            var itemList = await _dwellerItemQueryRepository.GetAllDwellerItems(houseId);
            if (itemList == null)
            {
                _logger.LogInformation("No items found or registered");
                response.IsSuccess = false;
                response.ErrorMessage = "No items could be found for household";
                return response;
            }

            response.IsSuccess = true;
            response.Data = itemList;
            return response;
        }
    }
}
