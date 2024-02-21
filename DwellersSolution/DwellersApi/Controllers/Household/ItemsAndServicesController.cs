using Dwellers.Common.Application.Contracts.Commands.DwellerEvents;
using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Contracts.Queries.Offerings;
using Dwellers.Common.Application.Contracts.Requests.Offerings;
using Dwellers.Offerings.Services.DwellerItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using System.Security.Authentication;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;


namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("providing")]
    public class ItemsAndServicesController : ControllerBase
    {
        private readonly DwellerItemCommandService _dwellerItemCommandService;

        private readonly ICommandHandlerFactory _commandHandler;

        public ItemsAndServicesController(
          ICommandHandlerFactory commandHandler)
        {
            _commandHandler = commandHandler;
        }

        // DWELLER-ITEMS
        [HttpPost("AddDwellerItem")]
        public async Task<IActionResult> AddDwellerItem([FromForm] IFormFile itemPhoto)
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                return BadRequest("Invalid house-details");
            }

            var cmd = new AddDwellerItemCommand(
                DwellingId: new Guid(houseIdClaim.Value),
                Name: Request.Form["name"],
                Desc: Request.Form["description"],
                ItemScope: Request.Form["itemScope"],
                ItemPhoto: itemPhoto);

            var handler = _commandHandler.GetHandler<AddDwellerItemCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("RemoveDwellerItem")]
        public async Task<IActionResult> RemoveDwellerItem(RemoveDwellerItemRequest request)
        {
            var cmd = new RemoveDwellerItemCommand(
                ItemId: request.ItemId);

            var handler = _commandHandler.GetHandler<RemoveDwellerItemCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetDwellerItem")]
        public async Task<IActionResult> GetDwellerItems(Guid itemId)
        {
            var query = new GetDwellerItemQuery(
                ItemId: itemId);

            var handler = _commandHandler.GetHandler<GetDwellerItemQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }


        [HttpGet("GetAllDwellerItems")]
        public async Task<IActionResult> GetAllDwellerItems(Guid houseId)
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var query = new GetAllDwellerItemsQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var handler = _commandHandler.GetHandler<GetAllDwellerItemsQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DWELLER-SERVICES
        [HttpPost("AddDwellerService")]
        public async Task<IActionResult> AddDwellerService(AddDwellerServiceRequest request)
        {
            var houseIdClaim = User.FindFirst("HouseId");
            if (houseIdClaim is null)
                throw new InvalidCredentialException();

            var cmd = new AddDwellerServiceCommand(
                DwellingId: new Guid(houseIdClaim.Value),
                Name: request.Name,
                Description: request.Description,
                ServiceScope: request.ServiceScope);

            var handler = _commandHandler.GetHandler<AddDwellerServiceCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetAllDwellerServices")]
        public async Task<IActionResult> GetAllDwellerServices()
        {
            var houseIdClaim = User.FindFirst("HouseId");
            if (houseIdClaim is null)
                throw new InvalidCredentialException();
           

            var query = new GetAllDwellerServicesQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var handler = _commandHandler.GetHandler<GetAllDwellerServicesQuery, DwellerUnit>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
