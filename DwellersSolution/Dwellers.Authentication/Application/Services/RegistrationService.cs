using Dwellers.Authentication.Application.Interfaces;
using Dwellers.Authentication.Application.Services.Responses;
using Dwellers.Authentication.Domain;

namespace Dwellers.Authentication.Application.Services
{
    public class RegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        public async Task<RegisterServiceResponse<DwellerUser>> Register(string email, string alias, string password)
        {

            RegisterServiceResponse<DwellerUser> serviceResponse = new RegisterServiceResponse<DwellerUser> ();

            if (await _registrationRepository.CheckNoUserExist(email))
            {
                serviceResponse.ErrorMessage = "There was already another user with that email.";
                serviceResponse.IsSuccess = false;
                return serviceResponse;
            }

            var user = new DwellerUser();
            var userCreationResult = user.CreateUser(email, email, alias);
            if (!userCreationResult.IsSuccess)
            {
                serviceResponse.ErrorMessage = userCreationResult.Info;
                serviceResponse.IsSuccess = false;
                return serviceResponse;
            }

            var result = await _registrationRepository.AddUser(user, password);
            if (!result.Succeeded)
            {
                serviceResponse.ErrorMessage = "User could not be added to database.";
                serviceResponse.IsSuccess = false;
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = user; 
            return serviceResponse;
        }
    }
}
