using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerItem;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerItems.Commands
{
    public record RemoveDwellerItemCommand(
        Guid ItemId
        ) : IRequest<RemoveDwellerItemResult>;

    public record RemoveDwellerItemResult(
        bool Success);

    public class RemoveDwellerItemCommandHandler : IRequestHandler<RemoveDwellerItemCommand, RemoveDwellerItemResult>
    {
        private readonly ILogger<RemoveDwellerItemCommandHandler> _logger;
        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;
        private readonly IDwellerItemQueryRepository _dwellerItemQueryRepository;

        public RemoveDwellerItemCommandHandler(
            ILogger<RemoveDwellerItemCommandHandler> logger,
            IDwellerItemCommandRepository dwellerItemCommandRepository,
            IDwellerItemQueryRepository dwellerItemQueryRepository)
        {
            _logger = logger;
            _dwellerItemCommandRepository = dwellerItemCommandRepository;
            _dwellerItemQueryRepository = dwellerItemQueryRepository;
        }

        public async Task<RemoveDwellerItemResult> Handle(RemoveDwellerItemCommand cmd, CancellationToken cancellationToken)
        {
            var dwellerItem = await _dwellerItemQueryRepository.GetDwellerItem(cmd.ItemId);
            if (dwellerItem == null)
            {
                _logger.LogInformation("Item could not be found");
                throw new EntityNotFoundException("Item could not be found");
            }
            if (!await _dwellerItemCommandRepository.RemoveDwellerItem(dwellerItem))
            {
                _logger.LogInformation("Could not persist item to database");
                throw new PersistanceFailedException("Item could not be persisted");
            }

            return new RemoveDwellerItemResult(
                Success: true);
        }
    }
}
