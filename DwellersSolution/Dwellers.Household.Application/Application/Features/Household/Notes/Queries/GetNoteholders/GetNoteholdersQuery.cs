using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholders
{
    public record GetNoteholdersQuery(
      Guid HouseId) : IRequest<GetNoteholdersResult>;
}
