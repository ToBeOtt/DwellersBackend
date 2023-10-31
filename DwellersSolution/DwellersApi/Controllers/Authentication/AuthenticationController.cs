using Dwellers.Authentication.Application.Services;
using Dwellers.Authentication.Contracts.Requests;
using Dwellers.Chat.Application.Services;
using Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterHouse;
using Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterMemberToHouse;
using Dwellers.Household.Application.Services;
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
        private readonly ChatCommandServices _chatCommandServices;
        private readonly RegistrationService _registrationService;
        private readonly AuthenticationService _authenticationService;
        private readonly HouseServices _houseServices;
        private readonly UserServices _userServices;

        public AuthenticationController(
            ISender mediator, 
            ChatCommandServices chatCommandServices,
            RegistrationService registrationService,
            AuthenticationService authenticationService,
            HouseServices houseServices,
            UserServices userServices
           )
        {
            _mediator = mediator;
            _chatCommandServices = chatCommandServices;
            _registrationService = registrationService;
            _authenticationService = authenticationService;
            _houseServices = houseServices;
            _userServices = userServices;
        }

    // REGISTRATION
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var identityUser = await _registrationService.Register
                (request.Email, request.Alias, request.Password);

            if (!identityUser.IsSuccess) return BadRequest(identityUser.ErrorMessage);

            var dwellerUser = await _userServices.CreateDwellerUser
                (identityUser.Data.Id, request.Email, request.Alias);

            if (!dwellerUser.IsSuccess) return BadRequest(dwellerUser.ErrorMessage);

            return Ok(identityUser.Data);
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

    // LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var idResult = await _houseServices.ServeGuidToAuthentication(email);
            if (!idResult.IsSuccess)
            {
                return BadRequest();
            }

            var result = await _authenticationService.Login
                (email, password, idResult.Data); // pass along houseID to pass it token-generation.
            if(!result.IsSuccess)
            {
                return Unauthorized(result.ErrorMessage);
            }

            return Ok(result.Data);
        }
    }
}
