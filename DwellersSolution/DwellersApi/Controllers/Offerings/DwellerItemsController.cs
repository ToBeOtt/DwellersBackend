using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Contracts.Queries.Offerings;
using Dwellers.Common.Application.Contracts.Requests.Offerings;
using Dwellers.Offerings.Services.DwellerItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using System.Security.Authentication;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;


namespace DwellersApi.Controllers.Offerings
{
    [ApiController]
    [Authorize]
    [Route("dwellerItems")]
    public class DwellerItemsController(
      ICommandHandlerFactory commandHandler) : ControllerBase
    {
        private readonly DwellerItemCommandService _dwellerItemCommandService;

        private readonly ICommandHandlerFactory _commandHandler = commandHandler;

        // DWELLER-ITEMS
        [HttpPost("AddDwellerItem")]
        public async Task<IActionResult> AddDwellerItem([FromForm] IFormFile itemPhoto)
        {
            var dwellingIdClaim = User.FindFirst("HouseId");

            if (dwellingIdClaim is null)
            {
                return BadRequest("Invalid dweller-details");
            }

            var cmd = new AddDwellerItemCommand(
                DwellingId: new Guid(dwellingIdClaim.Value),
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
    }
}
