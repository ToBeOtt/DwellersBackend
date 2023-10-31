//using Dwellers.Common.DAL.Models.DwellerItems;
//using Dwellers.Household.Application.Exceptions;
//using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
//using Dwellers.Household.Application.Interfaces.Houses;
//using Dwellers.Household.Domain.Entities.DwellerItems;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;

//namespace Dwellers.Household.Application.Features.Household.DwellerItems.Commands
//{
    //public record AddDwellerItemCommand(
    //    string Name,
    //    string Desc,
    //    string ItemScope,
    //    IFormFile ItemPhoto,
    //    Guid HouseId
    //    ) : IRequest<AddDwellerItemResult>;

//    public record AddDwellerItemResult(
//        bool Success);

//    public class AddDwellerItemCommandHandler : IRequestHandler<AddDwellerItemCommand, AddDwellerItemResult>
//    {
//        private readonly ILogger<AddDwellerItemCommandHandler> _logger;
//        private readonly IHouseQueryRepository _houseQueryRepository;
//        private readonly IDwellerItemCommandRepository _dwellerItemCommandRepository;

//        public AddDwellerItemCommandHandler(
//            ILogger<AddDwellerItemCommandHandler> logger,
//            IHouseQueryRepository houseQueryRepository,
//            IDwellerItemCommandRepository dwellerItemCommandRepository)
//        {
//            _logger = logger;
//            _houseQueryRepository = houseQueryRepository;
//            _dwellerItemCommandRepository = dwellerItemCommandRepository;
//        }

//        public async Task<AddDwellerItemResult> Handle(AddDwellerItemCommand cmd, CancellationToken cancellationToken)
//        {
//            var house = await _houseQueryRepository.GetHouseById(cmd.HouseId);
//            if (house is null)
//            {
//                _logger.LogInformation("Could not find entity in database");
//                throw new EntityNotFoundException("No house found");
//            }
//            var dwellerItem = new DwellerItem(cmd);

//            try
//            {
//                using (var memoryStream = new MemoryStream())
//                {
//                    await cmd.ItemPhoto.CopyToAsync(memoryStream);
//                    byte[] imageData = memoryStream.ToArray();

//                    dwellerItem.ItemPhoto = imageData;
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Item-photo could not be added.");
//            }

//            DwellerItemEntity dwellerItemEntity = new(
//                dwellerItem.Id,
//                dwellerItem.Name,
//                dwellerItem.Description,
//                dwellerItem.ItemStatus,
//                dwellerItem.ItemScope,
//                dwellerItem.DateAdded,
//                dwellerItem.ItemPhoto
//                );

//            if (!await _dwellerItemCommandRepository.AddDwellerItem(dwellerItemEntity))
//            {
//                _logger.LogInformation("Could not persist item to database");
//                throw new PersistanceFailedException("Item could not be persisted");
//            }

//            var establishOwnerShip = new BorrowedDwellerItem(house, dwellerItemEntity, true);
//            if (!await _dwellerItemCommandRepository.RegisterItemStatus(establishOwnerShip))
//            {
//                _logger.LogInformation("Could not persist item-ownership to database");
//                throw new PersistanceFailedException("Ownership of item could not be established could not be persisted");
//            }

//            return new AddDwellerItemResult(
//                Success: true);
//        }
//    }
//}
