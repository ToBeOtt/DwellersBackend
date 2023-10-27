using SharedKernel.Exceptions;

namespace Dwellers.Household.Application.Exceptions
{
    public class EntityNotFoundException : DwellersAppException
    {
        public EntityNotFoundException(string message) : base(message, 102)
        {
        }
    }
}
