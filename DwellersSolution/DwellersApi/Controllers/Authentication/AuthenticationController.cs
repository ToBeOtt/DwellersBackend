using Dwellers.Authentication.Application.Services;
using Dwellers.Authentication.Contracts.Requests;
using Dwellers.Chat.Services;
using Dwellers.DwellerCore.Contracts.Commands;
using Dwellers.DwellerCore.Contracts.Queries;
using Dwellers.DwellerCore.Contracts.Result;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Infrastructure.Configuration.Commands;
using static SharedKernel.ServiceResponse.EmptySuccessfulCommandResponse;

namespace DwellersApi.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ChatCommandServices _chatCommandServices;
        private readonly RegistrationService _registrationService;
        private readonly AuthenticationService _authenticationService;
        private readonly ICommandHandlerFactory _commandHandler;

        public AuthenticationController(
            ChatCommandServices chatCommandServices,
            RegistrationService registrationService,
            AuthenticationService authenticationService,
            ICommandHandlerFactory commandHandler
           )
        {
            _chatCommandServices = chatCommandServices;
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
            var cmd = new AttachDwellingToDwellerCommand(
                Name: request.Name,
                Description: request.Description,
                Email: request.Email);

            var handler = _commandHandler.GetHandler<AttachDwellingToDwellerCommand, AttachDwellingToDwellerResult>();
            var registerDwellingResult = await handler.Handle(cmd, new CancellationToken());
            if (!registerDwellingResult.IsSuccess)
            {
                return BadRequest(registerDwellingResult.ErrorMessage);
            }

            var establishConversationResult = await _chatCommandServices.EstablishConversation
                (registerDwellingResult.Data.DwellingId,
                 registerDwellingResult.Data.Name);
            
            if(!establishConversationResult.IsSuccess)
            {
                return BadRequest(establishConversationResult.ErrorMessage);
            }

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
