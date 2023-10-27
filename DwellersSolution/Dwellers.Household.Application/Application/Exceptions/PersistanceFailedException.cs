using SharedKernel.Exceptions;

namespace Dwellers.Household.Application.Exceptions
{
    public class PersistanceFailedException : DwellersAppException
    {
        public PersistanceFailedException(string message) : base(message, 102)
        {
        }
    }
}
