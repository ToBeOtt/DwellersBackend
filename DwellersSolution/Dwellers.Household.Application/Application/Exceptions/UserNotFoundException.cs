using SharedKernel.Exceptions;

namespace Dwellers.Household.Application.Exceptions
{
    public class UserNotFoundException : DwellersAppException
    {
        public UserNotFoundException(string message) : base(message, 102)
        {
        }
    }
}
