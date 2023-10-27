using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholders
{
    public class GetNoteholdersQueryValidator : AbstractValidator<GetNoteholdersQuery>
    {
        public GetNoteholdersQueryValidator()
        {

        }
    }
}