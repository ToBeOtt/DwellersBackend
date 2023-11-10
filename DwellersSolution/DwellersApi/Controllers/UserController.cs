using Dwellers.Bulletins.Application.Bulletins.Commands;
using Dwellers.Household.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;
using System.Security.Authentication;
using static Dwellers.Bulletins.Application.Bulletins.Queries.GetWolfQueryHandler;

namespace DwellersApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly ICommandHandlerFactory _commandHandler;
        private readonly IQueryHandlerFactory _queryHandler;

        public UserController(
            ISender mediator,
            ICommandHandlerFactory commandHandler,
            IQueryHandlerFactory queryHandler
            )
        {
            
            _mediator = mediator;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }


        [HttpPost("SetProfilePhoto")]
        public async Task<IActionResult> SetProfilePhoto(IFormFile profilePhoto)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new UpdateUserCommand(
                UserId: userIdClaim.Value,
                ProfilePhoto: profilePhoto);

            var UpdateUserResult = await _mediator.Send(cmd);
            return Ok(UpdateUserResult);
        }


        [HttpPost("SetSomething")]
        public async Task<IActionResult> SomeTest()
        {
            List<string> tagMock = new();
            List<Guid> houseMock = new();
            CancellationToken token = new();
            AddSomethingCommand cmd = new
                ("gfdgdf", "fdgsdf", "gdfstgfd", tagMock, "0", "1", "2", "gfdgd", houseMock);

            var handler = _commandHandler.GetHandler<AddSomethingCommand, AddSomethingResult>();
            
            await handler.Handle(cmd, new CancellationToken());
            return Ok();
        }

        [HttpPost("SetSomethingAgain")]
        public async Task<IActionResult> SomeTestAgain(Guid Id)
        {
            
            var handler = _queryHandler.GetHandler<GetWolfQuery, GetWolfQueryResult>();

            await handler.Handle(new GetWolfQuery(Id = Id), new CancellationToken());
            return Ok();
        }
    }
}