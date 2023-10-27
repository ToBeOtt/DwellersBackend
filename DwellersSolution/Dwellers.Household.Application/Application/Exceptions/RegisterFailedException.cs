using SharedKernel.Exceptions;

namespace Dwellers.Household.Application.Exceptions
{
    public class RegisterFailedException : DwellersAppException
    {
        public RegisterFailedException(string message) : base(message, 102)
        {
        }
    }
}
