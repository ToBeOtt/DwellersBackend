using Dwellers.Authentication.Application.Services;

namespace Dwellers.Authentication.Contracts.Interfaces
{
    public  interface IAuthenticationModuleService
    {
        RegistrationService RegistrationService { get; }
        AuthenticationService AuthenticationService { get; }
    }
}
