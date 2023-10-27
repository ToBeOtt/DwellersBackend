using Dwellers.Household.Application.Authentication.Commands.RegisterHouse;
using Dwellers.Household.Application.Authentication.Commands.RegisterMemberToHouse;
using Dwellers.Household.Application.Authentication.Queries.Login;
using Dwellers.Household.Application.Features.Authentication.Commands.Register;
using Dwellers.Household.Contracts.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DwellersApi.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(
            ISender mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
        }

    // REGISTRATION
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var cmd = new RegisterCommand(
                Email: request.Email,
                Alias: request.Alias,
                Password: request.Password);
            
            var authResult = await _mediator.Send(cmd);
            return Ok(authResult);
        }

        [HttpPost("RegisterHouse")]
        public async Task<IActionResult> RegisterHouse(RegisterHouseRequest request)
        {
            var cmd = new RegisterHouseCommand(
                Name: request.Name,
                Description: request.Description,
                Email: request.Email);

            var registerHouseResult = await _mediator.Send(cmd);
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
