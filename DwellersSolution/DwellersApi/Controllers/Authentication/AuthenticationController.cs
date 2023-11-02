using Dwellers.Authentication.Application.Services;
using Dwellers.Authentication.Contracts.Requests;
using Dwellers.Chat.Application.Services;
using Dwellers.Household.Contracts.Commands;
using Dwellers.Household.Contracts.Requests;
using Dwellers.Household.Services;
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
        private readonly HouseRegisterService _houseRegService;

        public AuthenticationController(
            ISender mediator, 
            ChatCommandServices chatCommandServices,
            RegistrationService registrationService,
            AuthenticationService authenticationService,
            HouseServices houseServices,
            UserServices userServices,
            HouseRegisterService houseRegService
           )
        {
            _mediator = mediator;
            _chatCommandServices = chatCommandServices;
            _registrationService = registrationService;
            _authenticationService = authenticationService;
            _houseServices = houseServices;
            _userServices = userServices;
            _houseRegService = houseRegService;
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

            if (!dwellerUser.IsSuccess) return BadRequest(dwellerUser.ErrorResponse);

            return Ok(identityUser.Data);
        }

        [HttpPost("RegisterHouse")]
        public async Task<IActionResult> RegisterHouse(RegisterHouseRequest request)
        {
            var cmd = new RegisterHouseCommand(
                Name: request.Name,
                Description: request.Description,
                Email: request.Email);

            var regResult = await _houseRegService.AttachHouseToUser(cmd);

            // Convert Guid? from registerHouseResponseDTO to a set Guid.
            Guid houseID = (Guid)regResult.Data.HouseId;
            var result = await _chatCommandServices.EstablishConversation
                (houseID,
                 regResult.Data.Name);
            
            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationMessage);
            }

            return Ok(result);
        }

        [HttpPost("RegisterMemberToHouse")]
        public async Task<IActionResult> RegisterMemberToHouse(RegisterMemberToHouseRequest request)
        {
            var cmd = new RegisterMemberToHouseCommand(
                Invitation: request.Invitation,
                Email: request.Email);

            var memberRegResult = await _houseRegService.AttachMemberToHouse(cmd);
            return Ok(memberRegResult);
        }

    // LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var idResult = await _houseServices.ServeGuidToAuthentication(request.Email);
            if (!idResult.IsSuccess)
            {
                return BadRequest();
            }

            var result = await _authenticationService.Login
                (request.Email, request.Password, idResult.Data); // pass along houseID to pass it token-generation.
            if(!result.IsSuccess)
            {
                return Unauthorized(result.ErrorMessage);
            }

            return Ok(result.Data);
        }
    }
}
