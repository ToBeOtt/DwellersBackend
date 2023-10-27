using SharedKernel.Exceptions;

namespace Dwellers.Household.Application.Exceptions
{
    public class LoginFailedException : DwellersAppException
    {
        public LoginFailedException(string message) : base(message, 401)
        {
        }
    }
}
