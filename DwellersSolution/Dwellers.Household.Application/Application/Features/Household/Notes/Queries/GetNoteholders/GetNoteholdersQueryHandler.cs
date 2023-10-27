using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Features.Household.Notes.Queries.GetNotes;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using MediatR;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholders
{
    public class GetNoteholdersQueryHandler : IRequestHandler<GetNoteholdersQuery, GetNoteholdersResult>
    {
        private readonly ILogger<GetNotesQueryHandler> _logger;
        private readonly INoteQueryRepository _noteQueryRepository;

        public GetNoteholdersQueryHandler(
            ILogger<GetNotesQueryHandler> logger,
            INoteQueryRepository noteQueryRepository
            )
        {
            _logger = logger;
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<GetNoteholdersResult> Handle(GetNoteholdersQuery query, CancellationToken cancellationToken)
        {
            var noteholders = await _noteQueryRepository.GetNoteholders(query.HouseId);
            if (noteholders is null)
            {
                _logger.LogInformation("Noteholders could not be found");
                throw new EntityNotFoundException("No noteholders could be associated with this household.");
            }

            return new GetNoteholdersResult(
                 Noteholders: noteholders
                 );
        }
    }
}
