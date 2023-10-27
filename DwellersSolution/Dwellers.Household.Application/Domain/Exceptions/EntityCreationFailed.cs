using SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Domain.Exceptions
{
    public class EntityCreationFailed : DwellersAppException
    {
        public EntityCreationFailed(string message) : base(message, 102)
        {
        }
    }
}
