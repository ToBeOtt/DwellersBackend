using Dwellers.Authentication.Application.Services;
using Dwellers.Authentication.Contracts.Requests;
using Dwellers.Common.Application.Contracts.Commands.Chats;
using Dwellers.Common.Application.Contracts.Commands.Dwellers;
using Dwellers.Common.Application.Contracts.Commands.Dwellings;
using Dwellers.Common.Application.Contracts.Commands.Offerings;
using Dwellers.Common.Application.Contracts.Queries.Dwellings;
using Dwellers.Common.Application.Contracts.Results.Dwellings;
using Dwellers.Common.Application.Interfaces.Chats;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IChatCommandRepository _chatCommandRepository;
        private readonly RegistrationService _registrationService;
        private readonly AuthenticationService _authenticationService;
        private readonly ICommandHandlerFactory _commandHandler;

        public AuthenticationController(
            IChatCommandRepository chatCommandRepository,
            RegistrationService registrationService,
            AuthenticationService authenticationService,
            ICommandHandlerFactory commandHandler
           )
        {
            _chatCommandRepository = chatCommandRepository;
            _registrationService = registrationService;
            _authenticationService = authenticationService;
            _commandHandler = commandHandler;
        }

    // REGISTRATION
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var identityUser = await _registrationService.Register
                (request.Email, request.Alias, request.Password);

            if (!identityUser.IsSuccess) return BadRequest(identityUser.ErrorMessage);

            var cmd = new AddDwellerCommand(
                DwellerId: identityUser.Data.DbUser.Id,
                Alias: request.Alias,
                Email: request.Email
                );

            var handler = _commandHandler.GetHandler<AddDwellerCommand, DwellerUnit>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

        [HttpPost("RegisterDwellingForDweller")]
        public async Task<IActionResult> RegisterDwellingForDweller(RegisterDwellingRequest request)
        {
            // Connect dwelling to the new dweller
            var cmd = new AttachDwellingToDwellerCommand(
                Name: request.Name,
                Description: request.Description,
                Email: request.Email);

            var registerHandler = _commandHandler.GetHandler<AttachDwellingToDwellerCommand, AttachDwellingToDwellerResult>();
            var registerDwellingResult = await registerHandler.Handle(cmd, new CancellationToken());
            if (!registerDwellingResult.IsSuccess)
                return BadRequest(registerDwellingResult.ErrorMessage);

            // Sets up a new conversation for the dwelling upon registration
            var cmdForConversation = new EstablishConversationCommand(
                            ListOfDwellingIds: [Guid.NewGuid()],                           
                            DwellingName: request.Name);

            var conversationHandler = _commandHandler.GetHandler<EstablishConversationCommand, DwellerUnit>();
            var establishConversationResult = await conversationHandler.Handle(cmdForConversation, new CancellationToken());

            if (!establishConversationResult.IsSuccess)
                return BadRequest(establishConversationResult.ErrorMessage);

            return Ok();
        }

        [HttpPost("RegisterDwellerToDwelling")]
        public async Task<IActionResult> RegisterDwellerToDwelling(RegisterDwellerToDwellingRequest request)
        {
            var cmd = new AttachDwellerToDwellingCommand(
                Invitation: request.Invitation,
                Email: request.Email);

            var handler = _commandHandler.GetHandler<AttachDwellerToDwellingCommand, AttachDwellerToDwellingResult>();
            var result = await handler.Handle(cmd, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

    // LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new GetDwellingByEmailQuery(
                Email: request.Email);

            var handler = _commandHandler.GetHandler<GetDwellingByEmailQuery, GetDwellingByEmailResult>();
            var result = await handler.Handle(query, new CancellationToken());

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            // pass along dwellingID to pass it token-generation.
            var loginResult = await _authenticationService.Login
                (request.Email, request.Password, result.Data.DwellingId); 
            if(!result.IsSuccess)
            {
                return Unauthorized(result.ErrorMessage);
            }

            return Ok(result.Data);
        }
    }
}
