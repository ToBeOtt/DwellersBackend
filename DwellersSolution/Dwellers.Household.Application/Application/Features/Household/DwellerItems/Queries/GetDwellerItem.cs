using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerItems.Queries
{
    public record GetDwellerItemQuery(
       Guid ItemId) : IRequest<GetDwellerItemResult>;
    public record GetDwellerItemResult(
        DwellerItem DwellerItem);

    public class GetDwellerItemQueryHandler : IRequestHandler<GetDwellerItemQuery, GetDwellerItemResult>
    {
        private readonly ILogger<GetDwellerItemQueryHandler> _logger;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;

        public GetDwellerItemQueryHandler(
            ILogger<GetDwellerItemQueryHandler> logger,
            IDwellerItemQueryRepository dwellerItemQueryRepository
            )
        {
            _logger = logger;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
        }

        public async Task<GetDwellerItemResult> Handle(GetDwellerItemQuery query, CancellationToken cancellationToken)
        {
            var item = await _dwellerItemQueryRepository.GetDwellerItem(query.ItemId);
            if (item == null)
            {
                _logger.LogInformation("No item could be found or registered");
                throw new EntityNotFoundException("No item could be found");
            }

            return new GetDwellerItemResult(
                DwellerItem: item);
        }
    }
}
