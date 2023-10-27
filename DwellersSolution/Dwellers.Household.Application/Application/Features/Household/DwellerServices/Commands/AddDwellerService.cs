using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerServices;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.DwellerServices.Commands
{
    public record AddDwellerServiceCommand(
       string Name,
       string Description,
       string ServiceScope,
       Guid HouseId
       ) : IRequest<AddDwellerServiceResult>;

    public record AddDwellerServiceResult(
        bool Success);

    public class AddDwellerServiceCommandHandler : IRequestHandler<AddDwellerServiceCommand, AddDwellerServiceResult>
    {
        private readonly ILogger<AddDwellerServiceCommandHandler> _logger;
        private readonly IHouseQueryRepository _houseQueryRepository;
        private readonly IDwellerServiceCommandRepository _dwellerServiceCommandRepository;

        public AddDwellerServiceCommandHandler(
            ILogger<AddDwellerServiceCommandHandler> logger,
            IHouseQueryRepository houseQueryRepository,
            IDwellerServiceCommandRepository dwellerServiceCommandRepository)
        {
            _logger = logger;
            _houseQueryRepository = houseQueryRepository;
            _dwellerServiceCommandRepository = dwellerServiceCommandRepository;
        }

        public async Task<AddDwellerServiceResult> Handle(AddDwellerServiceCommand cmd, CancellationToken cancellationToken)
        {
            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
            if (house is null)
            {
                _logger.LogInformation("Could not find entity in database");
                throw new EntityNotFoundException("No house found");
            }

            var dwellerService = new DwellerService(cmd);

            // NEW JOIN

            if (!await _dwellerServiceCommandRepository.AddDwellerService(dwellerService))
            {
                _logger.LogInformation("Could not persist item to database");
                throw new PersistanceFailedException("Item could not be persisted");
            }

            return new AddDwellerServiceResult(
                Success: true);
        }
    }
}
