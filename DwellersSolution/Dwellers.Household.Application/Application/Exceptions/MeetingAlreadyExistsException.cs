using SharedKernel.Exceptions;

namespace Dwellers.Household.Application.Exceptions
{
    public class MeetingAlreadyExistsException : DwellersAppException
    {
        public MeetingAlreadyExistsException(string message) : base(message, 102)
        {
        }
    }
}
