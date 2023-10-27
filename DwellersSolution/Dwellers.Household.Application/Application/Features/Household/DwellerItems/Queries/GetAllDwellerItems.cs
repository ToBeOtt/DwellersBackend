using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerEvents;
using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerItems.Queries
{
    public record GetAllDwellerItemsQuery(
       Guid HouseId) : IRequest<GetAllDwellerItemsResult>;
    public record GetAllDwellerItemsResult(
        ICollection<DwellerItem> DwellerItems);

    public class GetAllDwellerItemsQueryHandler : IRequestHandler<GetAllDwellerItemsQuery, GetAllDwellerItemsResult>
    {
        private readonly ILogger<GetAllDwellerItemsQueryHandler> _logger;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;

        public GetAllDwellerItemsQueryHandler(
            ILogger<GetAllDwellerItemsQueryHandler> logger,
            IDwellerItemQueryRepository dwellerItemQueryRepository
            )
        {
            _logger = logger;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
        }

        public async Task<GetAllDwellerItemsResult> Handle(GetAllDwellerItemsQuery query, CancellationToken cancellationToken)
        {
            var itemList = await _dwellerItemQueryRepository.GetAllDwellerItems(query.HouseId);
            if (itemList == null)
            {
                _logger.LogInformation("No items found or registered");
                throw new EntityNotFoundException("No items could be found");
            }

            return new GetAllDwellerItemsResult(
                DwellerItems: itemList);
        }
    }
}
