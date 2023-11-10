using Dwellers.Bulletins.Application.Bulletins.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Dwellers.Bulletins.Contracts.Commands.BulletinCommands;
using static Dwellers.Bulletins.Contracts.Request.BulletinRequests;

namespace DwellersApi.Controllers.BulletinModule
{

    [ApiController]
    [Route("bulletin")]
    public class BulletinController : ControllerBase
    {
        private readonly ISender _mediator;


        public BulletinController(
            ISender mediator)
        {
            _mediator = mediator;
        }

        // DWELLER-ITEMS
        [HttpPost("AddBulletinItem")]
        public async Task<IActionResult> AddBulletinPost(AddBulletinRequest request)
        {
            //var userId = User.FindFirst("UserId");

            //if (userId is null)
            //{
            //    return BadRequest("Invalid user");
            //}
            string tempUserID = "stringId";

            var cmd = new AddBulletinCommand(
                      UserId: tempUserID,
                      Title: request.Name,
                      Text: request.Desc,
                      BulletinPriority: request.BulletinPriority,
                      BulletinStatus: request.BulletinStatus,
                      BulletinTags: request.BulletinTags,
                      ChosenHouses: request.ChosenHouses,
                      Visibility: request.Visibility
                      );


            var result = await _mediator.Send(cmd);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}