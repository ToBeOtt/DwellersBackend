using Dwellers.Bulletins.Application.Bulletins.Commands.AddBulletin;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using static Dwellers.Bulletins.Contracts.Request.BulletinRequests;
using static SharedKernel.Application.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers.BulletinModule
{

    [ApiController]
    [Route("bulletin")]
    public class BulletinController : ControllerBase
    {
        private readonly ICommandHandlerFactory _commandHandler;

        public BulletinController(
          ICommandHandlerFactory commandHandler)
        {
            _commandHandler = commandHandler;
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

            var tempUserId = "f845394++5+040";
            var cmd = new AddBulletinCommand(
                      UserId: tempUserId,
                      //UserId: userId.Value,
                      Title: request.Title,
                      Text: request.Text,
                      BulletinTags: request.BulletinTags,
                      BulletinStatus: request.BulletinStatus,
                      BulletinPriority: request.BulletinPriority,
                      Visibility: request.Visibility,
                      ChosenHouses: request.ChosenHouses
            ); ;

            var handler = _commandHandler.GetHandler<AddBulletinCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}