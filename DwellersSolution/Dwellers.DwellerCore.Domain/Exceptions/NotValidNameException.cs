using SharedKernel.Exceptions;

namespace Dwellers.DwellerCore.Domain.Exceptions
{
    public class NotValidNameException : DwellersAppException
    {
        public NotValidNameException() : base("Name is required.", 400)
        {
        }
    }
}
