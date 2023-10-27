using Dwellers.Household.Application.Features.Household.DwellerItems.Commands;
using Dwellers.Household.Application.Features.Household.DwellerItems.Queries;
using Dwellers.Household.Application.Features.Household.DwellerServices.Commands;
using Dwellers.Household.Application.Features.Household.DwellerServices.Queries;
using Dwellers.Household.Contracts.Requests.Household.DwellerItems;
using Dwellers.Household.Contracts.Requests.Household.DwellerServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;


namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("providing")]
    public class ItemsAndServicesController : ControllerBase
    {
        private readonly ISender _mediator;

        public ItemsAndServicesController(
            ISender mediator)
        {
            _mediator = mediator;
        }

        // DWELLER-ITEMS
        [HttpPost("AddDwellerItem")]
        public async Task<IActionResult> AddDwellerItem([FromForm] IFormFile itemPhoto)
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new AddDwellerItemCommand(
                HouseId: new Guid(houseIdClaim.Value),
                Name: Request.Form["name"],
                Desc: Request.Form["description"],
                ItemScope: Request.Form["itemScope"],
                ItemPhoto: itemPhoto);

            var addDwellerItemResult = await _mediator.Send(cmd);
            return Ok(addDwellerItemResult);
        }

        [HttpPost("RemoveDwellerItem")]
        public async Task<IActionResult> RemoveDwellerItem(RemoveDwellerItemRequest request)
        {
            
            var cmd = new RemoveDwellerItemCommand(
                ItemId: request.ItemId);

            var removeDwellerItemResult = await _mediator.Send(cmd);
            return Ok(removeDwellerItemResult);
        }

        [HttpGet("GetDwellerItem")]
        public async Task<IActionResult> GetDwellerItems(Guid itemId)
        {
            var cmd = new GetDwellerItemQuery(
                ItemId: itemId);
    

            var getAllDwellerItemsResult = await _mediator.Send(cmd);
            return Ok(getAllDwellerItemsResult);
        }


        [HttpGet("GetAllDwellerItems")]
        public async Task<IActionResult> GetAllDwellerItems(Guid houseId)
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new GetAllDwellerItemsQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var getAllDwellerItemsResult = await _mediator.Send(cmd);
            return Ok(getAllDwellerItemsResult);
        }

        // DWELLER-SERVICES
        [HttpPost("AddDwellerService")]
        public async Task<IActionResult> AddDwellerService(AddDwellerServiceRequest request)
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new AddDwellerServiceCommand(
                HouseId: new Guid(houseIdClaim.Value),
                Name: request.Name,
                Description: request.Description,
                ServiceScope: request.ServiceScope);

            var addDwellerServiceResult = await _mediator.Send(cmd);
            return Ok(addDwellerServiceResult);
        }

        [HttpGet("GetAllDwellerServices")]
        public async Task<IActionResult> GetAllDwellerServices()
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new GetAllDwellerServicesQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var getAllDwellerServicesResult = await _mediator.Send(cmd);
            return Ok(getAllDwellerServicesResult);
        }
    }
}
