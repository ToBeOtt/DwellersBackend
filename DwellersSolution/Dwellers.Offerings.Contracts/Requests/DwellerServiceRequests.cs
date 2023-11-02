using Dwellers.Offerings.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Offerings.Contracts.Requests
{
    public record AddDwellerServiceRequest(
         Guid HouseId,
         string Name,
         string Description,
         string ServiceScope);
}