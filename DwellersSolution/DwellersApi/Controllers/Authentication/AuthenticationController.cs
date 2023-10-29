using Dwellers.Authentication.Contracts.Interfaces;
using Dwellers.Authentication.Contracts.Requests;
using Dwellers.Chat.Application.Services;
using Dwellers.Household.Application.Authentication.Commands.RegisterHouse;
using Dwellers.Household.Application.Authentication.Commands.RegisterMemberToHouse;
using Dwellers.Household.Application.Authentication.Queries.Login;
using Dwellers.Household.Application.Features.Authentication.Commands.Register;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DwellersApi.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly ChatCommandServices _chatCommandServices;
        private readonly IAuthenticationModuleService _authService;

        public AuthenticationController(
            ISender mediator, 
            IMapper mapper,
            ChatCommandServices chatCommandServices,
            IAuthenticationModuleService authService
           )
        {
            _mediator = mediator;
            _chatCommandServices = chatCommandServices;
            _authService = authService;
        }

    // REGISTRATION
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegistrationService.Register
                (request.Email, request.Alias, request.Password);

            if(!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPost("RegisterHouse")]
        public async Task<IActionResult> RegisterHouse(RegisterHouseRequest request)
        {
            var cmd = new RegisterHouseCommand(
                Name: request.Name,
                Description: request.Description,
                Email: request.Email);

            var registerHouseResult = await _mediator.Send(cmd);

            var result = await _chatCommandServices.EstablishConversation
                (registerHouseResult.House.HouseId,
                 registerHouseResult.House.Name);
            
            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationMessage);
            }

            return Ok(registerHouseResult);
        }

        [HttpPost("RegisterMemberToHouse")]
        public async Task<IActionResult> RegisterMemberToHouse(RegisterMemberToHouseRequest request)
        {
            var cmd = new RegisterMemberToHouseCommand(
                Invitation: request.Invitation,
                Email: request.Email);

            var registerMemberToHouseResult = await _mediator.Send(cmd);
            return Ok(registerMemberToHouseResult);
        }

    // REGISTRATION
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginQuery = new LoginQuery(
                Email: request.Email,
                Password: request.Password);

            var loginResult = await _mediator.Send(loginQuery);
            return Ok(loginResult);
        }
    }
}
